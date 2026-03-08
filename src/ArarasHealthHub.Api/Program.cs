using System.Reflection;
using System.Text.Json;

using araras_health_hub_api.Authorization;

using ArarasHealthHub.Api.Middlewares;
using ArarasHealthHub.Application.Behaviors;
using ArarasHealthHub.Application.Common.Interfaces;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Application.Features.Employees.Queries.GetAllEmployees;
using ArarasHealthHub.Application.Features.Facilities.Queries.GetAllFacilities;
using ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories;
using ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetAllPackagingTypes;
using ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts;
using ArarasHealthHub.Application.Features.Receivings.Queries.GetAllReceivings;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetCriticalStockOverview;
using ArarasHealthHub.Application.Features.Stocks.Queries.GetStockGeneralOverview;
using ArarasHealthHub.Application.Features.SubCategories.Queries.GetAllSubCategories;
using ArarasHealthHub.Application.Features.Suppliers.Queries.GetAllSuppliers;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Application.Profiles;
using ArarasHealthHub.Application.Services.StockAllocation;
using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Infrastructure.Data;
using ArarasHealthHub.Infrastructure.Repository;
using ArarasHealthHub.Infrastructure.Services;
using ArarasHealthHub.Shared;
using ArarasHealthHub.Shared.Messages;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var builder = WebApplication.CreateBuilder(args);

// ===============================================
// 1. CONFIGURAÇÃO DE AMBIENTE E BANCO DE DADOS
// ===============================================

// Lógica para determinar o DataSource com base no nome da máquina (uso em desenvolvimento)
var machineName = Environment.MachineName.ToLower();

string dataSource = machineName switch
{
    "desktop" => "desktop\\SQLEXPRESS",
    "notebook" => "notebook\\SQLEXPRESS",
    _ => "localhost\\SQLEXPRESS"
};

string connectionString = $"Data Source={dataSource};Initial Catalog=ararashealthhub;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

// Configuração do DbContext para o SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.CommandTimeout(90)
    );
});


// ===============================================
// 2. CONFIGURAÇÕES BÁSICAS DO ASP.NET CORE
// ===============================================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configura o uso de NewtonsoftJson para lidar com referência cíclica (Circular References)
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


// ===============================================
// 3. CONFIGURAÇÃO DO SWAGGER (OPENAPI)
// ===============================================

// Configuração da documentação e da segurança Bearer JWT no Swagger UI
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Araras Health Hub API",
        Version = "v1",
        Description = "API para gerenciamento do Araras Health Hub.",
    });

    // Define o esquema de segurança JWT Bearer
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer' [space] and then your valid token in the text input below.\n\nExample: \"Bearer eyJhbGciOiJIUzI1Ni...\"",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    // Adiciona o requisito de segurança globalmente
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });

    // Inclui comentários XML para documentação de endpoints (opcional)
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        option.IncludeXmlComments(xmlPath);
    }
});


// ===============================================
// 4. CONFIGURAÇÃO DE AUTENTICAÇÃO (IDENTITY & JWT)
// ===============================================

// Configuração do ASP.NET Core Identity
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// Configuração da Autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Parâmetros de validação do Token
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!)
        )
    };

    // Personaliza as respostas de 401 (Unauthorized) e 403 (Forbidden)
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            var response = new ApiResponseO<object>(
                StatusCodes.Status401Unauthorized,
                ApiMessages.AuthorizationRequired,
                (List<string>)null!,
                false
            );

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        },

        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";

            var response = new ApiResponseO<object>(
                StatusCodes.Status403Forbidden,
                ApiMessages.InsufficientPermissions,
                (List<string>)null!,
                false
            );

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    };
});


// ===============================================
// 5. CONFIGURAÇÃO DE AUTORIZAÇÃO (POLICIES)
// ===============================================

// Define as políticas de autorização baseadas em Claims e Requisitos
builder.Services.AddAuthorization(options =>
{
    // Políticas para gerenciamento de contas (requerem checagem hierárquica)
    options.AddPolicy("CanManageMasterAccount", policy =>
    {
        policy.AddRequirements(new ManageAccountRequirement(AccountScopeEnum.Management, AccountRoleEnum.Master));
    });
    options.AddPolicy("CanManageAdminOrUserAccount", policy =>
    {
        policy.AddRequirements(new ManageAccountRequirement(AccountScopeEnum.Management, AccountRoleEnum.Admin));
    });

    // Política para gerenciamento de recursos gerais (Employee, Facility, Product, Supplier)
    // Requer: Scope Management E (Role Master OU Admin)
    options.AddPolicy("CanManageResource", policy =>
    {
        policy.AddRequirements(new ResourceManagementRequirement());
    });

    // Política para leitura restrita (getAll, getById) de recursos de Management
    // Requer: Apenas Scope Management (Master, Admin, User)
    options.AddPolicy("CanReadManagementResource", policy =>
    {
        policy.RequireClaim("Scope", AccountScopeEnum.Management.ToString());
    });
});


// ===============================================
// 6. INJEÇÃO DE DEPENDÊNCIA (SERVICES, REPOSITORIES, HANDLERS)
// ===============================================

// Registra Repositórios e Interfaces de Infraestrutura
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IPackagingTypeRepository, PackagingTypeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
builder.Services.AddScoped<IReceivingRepository, ReceivingRepository>();
builder.Services.AddScoped<IReceivedItemRepository, ReceivedItemRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStockMovementRepository, StockMovementRepository>();
builder.Services.AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();
builder.Services.AddScoped<IStockAdjustmentItemRepository, StockAdjustmentItemRepository>();
builder.Services.AddScoped<IStockLotRepository, StockLotRepository>();
builder.Services.AddScoped<IStockCostRepository, StockCostRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IStockAllocationService, StockAllocationService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

// Registra os Authorization Handlers
builder.Services.AddScoped<IAuthorizationHandler, AccountManagementAuthorizationHandler>();
builder.Services.AddScoped<IAuthorizationHandler, ResourceManagementAuthorizationHandler>();


// ===============================================
// 7. CONFIGURAÇÃO DO MEDIATR (CQRS)
// ===============================================

// Configura o MediatR e registra Handlers/Comandos/Queries
builder.Services.AddMediatR(cfg =>
{
    // Registra Handlers/Comandos/Queries de todos os assemblies necessários
    cfg.RegisterServicesFromAssembly(typeof(GetAllSuppliersQuery).Assembly);
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

    // Adiciona Behaviors de Pipeline (ex: Validação e Transação)
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
});


// ===============================================
// 8. CONFIGURAÇÃO DE MAPPERS E VALIDATORS
// ===============================================

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(SupplierProfile).Assembly);
builder.Services.AddAutoMapper(typeof(EmployeeProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
builder.Services.AddAutoMapper(typeof(MainCategoryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(SubCategoryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PackagingTypeProfile).Assembly);
builder.Services.AddAutoMapper(typeof(FacilityProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ReceivingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(AccountProfile).Assembly);
builder.Services.AddAutoMapper(typeof(StockProfile).Assembly);

// Configuração do FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(GetAllSuppliersQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllEmployeesQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllProductsQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllMainCategoriesQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllSubCategoriesQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllPackagingTypesQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllFacilitiesQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllReceivingsQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetAllAccountsQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetStockGeneralOverviewQuery).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GetCriticalStockOverviewQuery).Assembly);


// ===============================================
// 9. CONFIGURAÇÃO DE CORS
// ===============================================

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "FrontEndUI", policy =>
    {
        // Política permissiva para desenvolvimento
        policy.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("Content-Disposition");
    });
});


// ===============================================
// 10. PIPELINE DE REQUISIÇÃO HTTP
// ===============================================

var app = builder.Build();

// Configuração do pipeline HTTP para o ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "Araras Health Hub API v1");
        option.RoutePrefix = string.Empty;
        option.DocumentTitle = "Araras Health Hub API Documentation";
    });
}

app.UseCors("FrontEndUI");

app.UseHttpsRedirection();

// Middleware customizado para capturar e formatar exceções (tratamento de erros global)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Adiciona os middlewares de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
