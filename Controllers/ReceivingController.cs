using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Receiving;
using araras_health_hub_api.Dtos.Supplier;
using araras_health_hub_api.Dtos.Employee;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using araras_health_hub_api.Dtos.Product;

namespace araras_health_hub_api.Controllers
{
    [Route("api/receiving")]
    [ApiController]
    public class ReceivingController : ControllerBase
    {
        private readonly IReceivingRepository _receivingRepo;
        private readonly ApplicationDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;

        public ReceivingController(IReceivingRepository receivingRepo, ApplicationDBContext dbContext, UserManager<AppUser> userManager, IStockRepository stockRepo)
        {
            _receivingRepo = receivingRepo;
            _dbContext = dbContext;
            _userManager = userManager;
            _stockRepo = stockRepo;
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateReceivingRequestDto receivingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<Receiving>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var responsibleUser = await _dbContext.Employee.FindAsync(receivingDto.ResponsibleId);
            if (responsibleUser == null)
            {
                return BadRequest(new ApiResponse<Receiving>(StatusCodes.Status400BadRequest, ApiMessages.MsgEmployeeInvalid, null!));
            }

            var account = await _userManager.FindByIdAsync(receivingDto.AccountId.ToString());
            if (account == null)
            {
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));
            }

            var receivingModel = new Receiving
            {
                InvoiceNumber = receivingDto.InvoiceNumber,
                SupplyAuthorization = receivingDto.SupplyAuthorization,
                ReceivingDate = receivingDto.ReceivingDate,
                Observation = receivingDto.Observation,
                TotalValue = receivingDto.TotalValue,
                SupplierId = receivingDto.SupplierId,
                ResponsibleId = receivingDto.ResponsibleId,
                AccountId = receivingDto.AccountId,
                ReceivedItems = new List<ReceivingItem>()
            };

            var newReceiving = await _receivingRepo.CreateAsync(receivingModel);

            if (receivingDto.ReceivedItems != null)
            {
                foreach (var itemDto in receivingDto.ReceivedItems)
                {
                    var receivingItemModel = new ReceivingItem
                    {
                        ReceivingId = newReceiving.Id,
                        ProductId = itemDto.ProductId,
                        Quantity = itemDto.Quantity,
                        UnitValue = itemDto.UnitValue,
                        TotalValue = itemDto.TotalValue,
                        Batch = itemDto.Batch,
                        ExpiryDate = itemDto.ExpiryDate,
                    };
                    await _receivingRepo.CreateReceivingItemAsync(receivingItemModel);

                    await _stockRepo.UpdateStock(itemDto.ProductId, itemDto.Quantity, itemDto.Batch);
                }
            }
            var response = await _receivingRepo.GetByIdAsync(newReceiving.Id);

            return CreatedAtAction(nameof(GetById), new { id = newReceiving.Id }, new ApiResponse<Receiving>(StatusCodes.Status201Created, ApiMessages.MsgReceivingCreatedSuccessfully, response!));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var receiving = await _receivingRepo.GetByIdAsync(id);

            if (receiving == null)
            {
                return NotFound(new ApiResponse<ReceivingResponseDto>(StatusCodes.Status404NotFound, ApiMessages.MsgReceivingNotFound, null!));
            }

            var receivingResponseDto = new ReceivingResponseDto
            {
                Id = receiving.Id,
                InvoiceNumber = receiving.InvoiceNumber,
                SupplyAuthorization = receiving.SupplyAuthorization,
                Observation = receiving.Observation!,
                ReceivingDate = receiving.ReceivingDate,
                TotalValue = receiving.TotalValue,
                SupplierId = receiving.SupplierId,
                Supplier = receiving.Supplier != null ? new SupplierDto
                {
                    Id = receiving.Supplier.Id,
                    Name = receiving.Supplier.Name,
                    Cnpj = receiving.Supplier.Cnpj,
                    Address = receiving.Supplier.Address,
                    Phone = receiving.Supplier.Phone,
                    Email = receiving.Supplier.Email
                } : null,
                ResponsibleId = receiving.ResponsibleId,
                Responsible = receiving.Responsible != null ? new EmployeeDto
                {
                    Id = receiving.Responsible.Id,
                    Name = receiving.Responsible.Name,
                    Cpf = receiving.Responsible.Cpf,
                    Phone = receiving.Responsible.Phone,
                    Function = receiving.Responsible.Function
                } : null,
                AccountId = receiving.AccountId,
                Account = receiving.Account != null ? new AppUser
                {
                    Id = receiving.Account.Id,
                    UserName = receiving.Account.UserName,
                    Email = receiving.Account.Email
                } : null,
                ReceivedItems = receiving.ReceivedItems?.Select(item => new ReceivingItemResponseDto
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    UnitValue = item.UnitValue,
                    TotalValue = item.TotalValue,
                    Batch = item.Batch,
                    ExpiryDate = item.ExpiryDate,
                    ProductId = item.ProductId,
                    Product = item.Product != null ? new ProductDto
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        DosageForm = item.Product.DosageForm,
                        Category = item.Product.Category,
                    } : null,
                }).ToList() ?? new List<ReceivingItemResponseDto>()
            };

            return Ok(new ApiResponse<ReceivingResponseDto>(StatusCodes.Status200OK, ApiMessages.MsgReceivingFoundSuccessfully, receivingResponseDto));
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var receivings = await _receivingRepo.GetAllAsync();

            if (receivings == null || !receivings.Any())
            {
                return NotFound(new ApiResponse<List<ReceivingResponseDto>>(StatusCodes.Status404NotFound, ApiMessages.MsgNotReceivingsFound, null!));
            }

            var receivingResponseDtos = receivings.Select(receiving => new ReceivingResponseDto
            {
                Id = receiving.Id,
                InvoiceNumber = receiving.InvoiceNumber,
                SupplyAuthorization = receiving.SupplyAuthorization,
                Observation = receiving.Observation!,
                ReceivingDate = receiving.ReceivingDate,
                TotalValue = receiving.TotalValue,
                SupplierId = receiving.SupplierId,
                Supplier = receiving.Supplier != null ? new SupplierDto
                {
                    Id = receiving.Supplier.Id,
                    Name = receiving.Supplier.Name,
                    Cnpj = receiving.Supplier.Cnpj,
                    Address = receiving.Supplier.Address,
                    Phone = receiving.Supplier.Phone,
                    Email = receiving.Supplier.Email
                } : null,
                ResponsibleId = receiving.ResponsibleId,
                Responsible = receiving.Responsible != null ? new EmployeeDto
                {
                    Id = receiving.Responsible.Id,
                    Name = receiving.Responsible.Name,
                    Cpf = receiving.Responsible.Cpf,
                    Phone = receiving.Responsible.Phone,
                    Function = receiving.Responsible.Function
                } : null,
                AccountId = receiving.AccountId,
                Account = receiving.Account != null ? new AppUser
                {
                    Id = receiving.Account.Id,
                    UserName = receiving.Account.UserName,
                    Email = receiving.Account.Email
                } : null,
                ReceivedItems = receiving.ReceivedItems?.Select(item => new ReceivingItemResponseDto
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    UnitValue = item.UnitValue,
                    TotalValue = item.TotalValue,
                    Batch = item.Batch,
                    ExpiryDate = item.ExpiryDate,
                    ProductId = item.ProductId,
                    Product = item.Product != null ? new ProductDto
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        DosageForm = item.Product.DosageForm,
                        Category = item.Product.Category,
                    } : null,
                }).ToList() ?? new List<ReceivingItemResponseDto>()
            }).ToList();

            return Ok(new ApiResponse<List<ReceivingResponseDto>>(StatusCodes.Status200OK, ApiMessages.MsgReceivingsFoundSuccessfully, receivingResponseDtos));
        }
    }
}
