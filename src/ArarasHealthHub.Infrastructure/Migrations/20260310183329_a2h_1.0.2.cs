using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArarasHealthHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class a2h_102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome do funcionário"),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false, comment: "CPF"),
                    Function = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Função"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Telefone"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                },
                comment: "Representa um funcionário");

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome da unidade"),
                    Cnes = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false, comment: "Código CNES"),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "CEP"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Logradouro"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Número"),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Bairro"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Cidade"),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "UF"),
                    Complement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Complemento"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "E-mail"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Telefone"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                },
                comment: "Representa uma unidade");

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome da categoria principal"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                },
                comment: "Representa uma categoria principal de produtos (ex: Medicamento, Material Hospitalar, Material de Limpeza)");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                },
                comment: "Tabela de lookup para os status possíveis de um pedido");

            migrationBuilder.CreateTable(
                name: "PackagingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome do tipo de embalagem"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackagingTypes", x => x.Id);
                },
                comment: "Representa um tipo de embalagem do produto (ex: Frasco, Ampola, Comprimido)");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegalName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Razão Social"),
                    TradeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Nome Fantasia"),
                    Cnpj = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false, comment: "CNPJ"),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "CEP"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Logradouro"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Número"),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Bairro"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Cidade"),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, comment: "UF"),
                    Complement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Complemento"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "E-mail"),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Telefone"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                },
                comment: "Representa um fornecedor");

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    Scope = table.Column<byte>(type: "tinyint", nullable: false, comment: "Escopo da conta no sistema."),
                    Role = table.Column<byte>(type: "tinyint", nullable: false, comment: "Papel da conta no sistema."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação da conta."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização da conta."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se a conta está ativa."),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa uma conta de usuário do sistema");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome da subcategoria"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa uma subcategoria vinculada a categoria principal de produtos (ex: Antibiótico, Analgésico, Antialérgico)");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderFacilityId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedByAccountId = table.Column<int>(type: "int", nullable: false),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    ApprovedByAccountId = table.Column<int>(type: "int", nullable: true),
                    SeparatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeparatedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    SeparatedByAccountId = table.Column<int>(type: "int", nullable: true),
                    FinalizedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinalizedByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    FinalizedByAccountId = table.Column<int>(type: "int", nullable: true),
                    CanceledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CanceledByEmployeeId = table.Column<int>(type: "int", nullable: true),
                    CanceledByAccountId = table.Column<int>(type: "int", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ApplicationUsers_CreatedByAccountId",
                        column: x => x.CreatedByAccountId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_CreatedByEmployeeId",
                        column: x => x.CreatedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Facilities_OrderFacilityId",
                        column: x => x.OrderFacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receivings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplyAuthorization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivings_ApplicationUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivings_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receivings_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Representa o registro de entrada no estoque");

            migrationBuilder.CreateTable(
                name: "StockAdjustments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdjustmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponsibleId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_ApplicationUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustments_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa um ajuste manual na quantidade do estoque");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Nome do produto"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Descrição do produto"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    PackagingTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_PackagingTypes_PackagingTypeId",
                        column: x => x.PackagingTypeId,
                        principalTable: "PackagingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa um produto");

            migrationBuilder.CreateTable(
                name: "DispenseReturns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalOrderId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedByEmployeeId = table.Column<int>(type: "int", nullable: false),
                    ReturnedByAccountId = table.Column<int>(type: "int", nullable: false),
                    TotalReturnedValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispenseReturns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispenseReturns_Orders_OriginalOrderId",
                        column: x => x.OriginalOrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa uma devolução de itens dispensados de um pedido ao estoque");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ApprovedQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ReservedQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ActualQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Batch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ReceivingId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivedItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceivedItems_Receivings_ReceivingId",
                        column: x => x.ReceivingId,
                        principalTable: "Receivings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Representa um item específico de um recebimento");

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CurrentQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false, comment: "Quantidade total disponível."),
                    ReservedQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    AvailableQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    MinQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Representa o estoque atual de um produto (visão consolidada)");

            migrationBuilder.CreateTable(
                name: "StockCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    AverageUnitCost = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CurrentTotalCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockCosts_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Armazena o custo médio unitário e o custo total atual do estoque consolidado");

            migrationBuilder.CreateTable(
                name: "StockLots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Batch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Número do lote"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableQuantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    ReceivedItemId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLots_ReceivedItems_ReceivedItemId",
                        column: x => x.ReceivedItemId,
                        principalTable: "ReceivedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockLots_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Representa o estoque detalhado de um produto por lote, valor e validade");

            migrationBuilder.CreateTable(
                name: "DispenseReturnItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispenseReturnId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockLotId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Batch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DispenseReturnId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispenseReturnItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DispenseReturnItems_DispenseReturns_DispenseReturnId",
                        column: x => x.DispenseReturnId,
                        principalTable: "DispenseReturns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DispenseReturnItems_DispenseReturns_DispenseReturnId1",
                        column: x => x.DispenseReturnId1,
                        principalTable: "DispenseReturns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DispenseReturnItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DispenseReturnItems_StockLots_StockLotId",
                        column: x => x.StockLotId,
                        principalTable: "StockLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemLots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    StockLotId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderItemId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemLots_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemLots_OrderItems_OrderItemId1",
                        column: x => x.OrderItemId1,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItemLots_StockLots_StockLotId",
                        column: x => x.StockLotId,
                        principalTable: "StockLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Registra os lotes específicos usados para atender um item de pedido durante a separação");

            migrationBuilder.CreateTable(
                name: "StockAdjustmentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockAdjustmentId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockLotId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Batch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StockAdjustmentId1 = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_StockAdjustments_StockAdjustmentId",
                        column: x => x.StockAdjustmentId,
                        principalTable: "StockAdjustments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_StockAdjustments_StockAdjustmentId1",
                        column: x => x.StockAdjustmentId1,
                        principalTable: "StockAdjustments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_StockLots_StockLotId",
                        column: x => x.StockLotId,
                        principalTable: "StockLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa um item específico do ajuste manual na quantidade do estoque");

            migrationBuilder.CreateTable(
                name: "StockMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador único do registro.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceDocumentId = table.Column<int>(type: "int", nullable: false),
                    SourceDocumentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResponsibleId = table.Column<int>(type: "int", nullable: false),
                    StockLotId = table.Column<int>(type: "int", nullable: false),
                    MovementCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data de criação do registro."),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Data da última atualização do registro."),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Indica se o registro está ativo.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockMovements_Employees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockMovements_StockLots_StockLotId",
                        column: x => x.StockLotId,
                        principalTable: "StockLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Representa uma entrada ou saída de itens do estoque");

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Cnes", "CreatedOn", "IsActive", "Name", "UpdatedOn", "Cep", "City", "Complement", "Neighborhood", "Number", "State", "Street", "Email", "Phone" },
                values: new object[] { 1, "6345921", new DateTime(2025, 1, 2, 8, 35, 14, 0, DateTimeKind.Utc), true, "Secretária Municipal da Saúde - Dr. João Geraldo Noronha", null, "13601-111", "Araras", "", "Jardim Belvedere", "33", "SP", "Rua Campos Sales", "saude@araras.sp.gov.br", "(19) 3543-1522" });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "CreatedOn", "Description", "IsActive", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pendente de Aprovação", true, null },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pronto para Separação", true, null },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Em Separação", true, null },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Pronto para Envio/Finalização", true, null },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Finalizado", true, null },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cancelado", true, null }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FacilityId", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "Scope", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserName" },
                values: new object[] { 1, 0, "3F1C7B9A-1C8E-4E3B-A4F5-8C6B7F2E1D99", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "", false, 1, true, false, null, "", "SAUDE_MASTER", "AQAAAAIAAYagAAAAEEqeBGF+Rvx70SKaJEf8a7fAWWMLi+icLvnqu5uiLw3uR23FB+X6dxnr0jBGFs2ZnA==", null, false, (byte)1, (byte)1, "D8A2F6E1-7B32-4C6F-BB5A-91C3E62E8A11", false, null, "saude_master" });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_FacilityId",
                table: "ApplicationUsers",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "ApplicationUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseReturnItems_DispenseReturnId",
                table: "DispenseReturnItems",
                column: "DispenseReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseReturnItems_DispenseReturnId1",
                table: "DispenseReturnItems",
                column: "DispenseReturnId1");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseReturnItems_ProductId",
                table: "DispenseReturnItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseReturnItems_StockLotId",
                table: "DispenseReturnItems",
                column: "StockLotId");

            migrationBuilder.CreateIndex(
                name: "IX_DispenseReturns_OriginalOrderId",
                table: "DispenseReturns",
                column: "OriginalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Cpf",
                table: "Employees",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainCategories_Name",
                table: "MainCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemLots_OrderItemId",
                table: "OrderItemLots",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemLots_OrderItemId1",
                table: "OrderItemLots",
                column: "OrderItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemLots_StockLotId",
                table: "OrderItemLots",
                column: "StockLotId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId1",
                table: "OrderItems",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedByAccountId",
                table: "Orders",
                column: "CreatedByAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedByEmployeeId",
                table: "Orders",
                column: "CreatedByEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderFacilityId",
                table: "Orders",
                column: "OrderFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PackagingTypes_Name",
                table: "PackagingTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MainCategoryId",
                table: "Products",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PackagingTypeId",
                table: "Products",
                column: "PackagingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedItems_ProductId",
                table: "ReceivedItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedItems_ReceivingId",
                table: "ReceivedItems",
                column: "ReceivingId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_AccountId",
                table: "Receivings",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_ResponsibleId",
                table: "Receivings",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivings_SupplierId",
                table: "Receivings",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_ProductId",
                table: "StockAdjustmentItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_StockAdjustmentId",
                table: "StockAdjustmentItems",
                column: "StockAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_StockAdjustmentId1",
                table: "StockAdjustmentItems",
                column: "StockAdjustmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_StockLotId",
                table: "StockAdjustmentItems",
                column: "StockLotId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_AccountId",
                table: "StockAdjustments",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustments_ResponsibleId",
                table: "StockAdjustments",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_StockCosts_StockId",
                table: "StockCosts",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockLots_ReceivedItemId",
                table: "StockLots",
                column: "ReceivedItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLots_StockId_Batch",
                table: "StockLots",
                columns: new[] { "StockId", "Batch" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_ResponsibleId",
                table: "StockMovements",
                column: "ResponsibleId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_StockLotId",
                table: "StockMovements",
                column: "StockLotId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_MainCategoryId_Name",
                table: "SubCategories",
                columns: new[] { "MainCategoryId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DispenseReturnItems");

            migrationBuilder.DropTable(
                name: "OrderItemLots");

            migrationBuilder.DropTable(
                name: "StockAdjustmentItems");

            migrationBuilder.DropTable(
                name: "StockCosts");

            migrationBuilder.DropTable(
                name: "StockMovements");

            migrationBuilder.DropTable(
                name: "DispenseReturns");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "StockAdjustments");

            migrationBuilder.DropTable(
                name: "StockLots");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ReceivedItems");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "Receivings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "PackagingTypes");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "MainCategories");
        }
    }
}
