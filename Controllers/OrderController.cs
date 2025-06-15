using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Employee;
using araras_health_hub_api.Dtos.Order;
using araras_health_hub_api.Dtos.Product;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using araras_health_hub_api.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ApplicationDBContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepo;

        public OrderController(IOrderRepository orderRepo, ApplicationDBContext dbContext, UserManager<AppUser> userManager, IStockRepository stockRepo)
        {
            _orderRepo = orderRepo;
            _dbContext = dbContext;
            _userManager = userManager;
            _stockRepo = stockRepo;
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var employee = await _dbContext.Employee.FindAsync(orderDto.CreatedByEmployeeId);
            if (employee == null)
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.MsgEmployeeInvalid, null!));

            var user = await _userManager.FindByIdAsync(orderDto.CreatedByAccountId.ToString());
            if (user == null)
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));

            var status = await _dbContext.OrderStatus.FindAsync(orderDto.OrderStatusId);
            if (status == null)
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.MsgOrderStatusInvalid, null!));

            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                CreatedByEmployeeId = orderDto.CreatedByEmployeeId,
                CreatedByAccountId = orderDto.CreatedByAccountId,
                OrderStatusId = status.Id,
                Observation = orderDto.Observation!,
                OrderItems = new List<OrderItem>()
            };

            var createdOrder = await _orderRepo.CreateAsync(order);

            if (orderDto.OrderItems != null)
            {
                foreach (var itemDto in orderDto.OrderItems)
                {
                    var product = await _dbContext.Product.FindAsync(itemDto.ProductId);
                    if (product == null)
                        return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, $"Invalid product: {itemDto.ProductId}", null!));

                    var orderItem = new OrderItem
                    {
                        OrderId = createdOrder.Id,
                        ProductId = itemDto.ProductId,
                        RequestedQuantity = itemDto.RequestedQuantity,
                        ApprovedQuantity = 0,
                        ActualQuantity = 0
                    };

                    await _orderRepo.CreateOrderItemAsync(orderItem);
                }
            }

            var response = await _orderRepo.GetByIdAsync(createdOrder.Id);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, new ApiResponse<Order>(StatusCodes.Status201Created, ApiMessages.MsgOrderCreatedSuccessfully, response!));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound(new ApiResponse<OrderResponseDto>(StatusCodes.Status404NotFound, ApiMessages.MsgOrderNotFound, null!));
            }

            var orderResponseDto = new OrderResponseDto
            {
                Id = order.Id,
                Observation = order.Observation!,
                CreatedAt = order.CreatedAt,
                CreatedByAccountId = order.CreatedByAccountId,
                CreatedByAccount = order.CreatedByAccount != null ? new AppUser
                {
                    Id = order.CreatedByAccount.Id,
                    UserName = order.CreatedByAccount.UserName,
                } : null,
                CreatedByEmployeeId = order.CreatedByEmployeeId,
                CreatedByEmployee = order.CreatedByEmployee != null ? new EmployeeDto
                {
                    Id = order.CreatedByEmployee.Id,
                    Name = order.CreatedByEmployee.Name,
                    Cpf = order.CreatedByEmployee.Cpf,
                } : null,
                ApprovedAt = order.ApprovedAt,
                ApprovedByAccountId = order.ApprovedByAccountId,
                ApprovedByAccount = order.ApprovedByAccount != null ? new AppUser
                {
                    Id = order.ApprovedByAccount.Id,
                    UserName = order.ApprovedByAccount.UserName,
                } : null,
                ApprovedByEmployeeId = order.ApprovedByEmployeeId,
                ApprovedByEmployee = order.ApprovedByEmployee != null ? new EmployeeDto
                {
                    Id = order.ApprovedByEmployee.Id,
                    Name = order.ApprovedByEmployee.Name,
                    Cpf = order.ApprovedByEmployee.Cpf,
                } : null,
                SeparatedAt = order.SeparatedAt,
                SeparatedByAccountId = order.SeparatedByAccountId,
                SeparatedByAccount = order.SeparatedByAccount != null ? new AppUser
                {
                    Id = order.SeparatedByAccount.Id,
                    UserName = order.SeparatedByAccount.UserName,
                } : null,
                SeparatedByEmployeeId = order.SeparatedByEmployeeId,
                SeparatedByEmployee = order.SeparatedByEmployee != null ? new EmployeeDto
                {
                    Id = order.SeparatedByEmployee.Id,
                    Name = order.SeparatedByEmployee.Name,
                    Cpf = order.SeparatedByEmployee.Cpf,
                } : null,
                FinalizedAt = order.FinalizedAt,
                FinalizedByAccountId = order.FinalizedByAccountId,
                FinalizedByAccount = order.FinalizedByAccount != null ? new AppUser
                {
                    Id = order.FinalizedByAccount.Id,
                    UserName = order.FinalizedByAccount.UserName,
                } : null,
                FinalizedByEmployeeId = order.FinalizedByEmployeeId,
                FinalizedByEmployee = order.FinalizedByEmployee != null ? new EmployeeDto
                {
                    Id = order.FinalizedByEmployee.Id,
                    Name = order.FinalizedByEmployee.Name,
                    Cpf = order.FinalizedByEmployee.Cpf,
                } : null,
                OrderStatusId = order.OrderStatusId,
                OrderStatus = order.OrderStatus != null ? new OrderStatus
                {
                    Id = order.OrderStatus.Id,
                    Description = order.OrderStatus.Description,
                } : null,

                OrderItems = order.OrderItems?.Select(item => new OrderItemResponseDto
                {
                    Id = item.Id,
                    RequestedQuantity = item.RequestedQuantity,
                    ApprovedQuantity = item.ApprovedQuantity,
                    ActualQuantity = item.ActualQuantity,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Product = item.Product != null ? new ProductDto
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        DosageForm = item.Product.DosageForm,
                        Category = item.Product.Category,
                    } : null,
                }).ToList() ?? new List<OrderItemResponseDto>()
            };

            return Ok(new ApiResponse<OrderResponseDto>(StatusCodes.Status200OK, ApiMessages.MsgOrderFoundSuccessfully, orderResponseDto));
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderRepo.GetAllAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound(new ApiResponse<List<OrderResponseDto>>(StatusCodes.Status404NotFound, ApiMessages.MsgNotOrdersFound, null!));
            }

            var orderResponseDtos = orders.Select(order => new OrderResponseDto
            {
                Id = order.Id,
                Observation = order.Observation!,
                CreatedAt = order.CreatedAt,
                CreatedByAccountId = order.CreatedByAccountId,
                CreatedByAccount = order.CreatedByAccount != null ? new AppUser
                {
                    Id = order.CreatedByAccount.Id,
                    UserName = order.CreatedByAccount.UserName,
                } : null,
                CreatedByEmployeeId = order.CreatedByEmployeeId,
                CreatedByEmployee = order.CreatedByEmployee != null ? new EmployeeDto
                {
                    Id = order.CreatedByEmployee.Id,
                    Name = order.CreatedByEmployee.Name,
                    Cpf = order.CreatedByEmployee.Cpf,
                } : null,
                ApprovedAt = order.ApprovedAt,
                ApprovedByAccountId = order.ApprovedByAccountId,
                ApprovedByAccount = order.ApprovedByAccount != null ? new AppUser
                {
                    Id = order.ApprovedByAccount.Id,
                    UserName = order.ApprovedByAccount.UserName,
                } : null,
                ApprovedByEmployeeId = order.ApprovedByEmployeeId,
                ApprovedByEmployee = order.ApprovedByEmployee != null ? new EmployeeDto
                {
                    Id = order.ApprovedByEmployee.Id,
                    Name = order.ApprovedByEmployee.Name,
                    Cpf = order.ApprovedByEmployee.Cpf,
                } : null,
                SeparatedAt = order.SeparatedAt,
                SeparatedByAccountId = order.SeparatedByAccountId,
                SeparatedByAccount = order.SeparatedByAccount != null ? new AppUser
                {
                    Id = order.SeparatedByAccount.Id,
                    UserName = order.SeparatedByAccount.UserName,
                } : null,
                SeparatedByEmployeeId = order.SeparatedByEmployeeId,
                SeparatedByEmployee = order.SeparatedByEmployee != null ? new EmployeeDto
                {
                    Id = order.SeparatedByEmployee.Id,
                    Name = order.SeparatedByEmployee.Name,
                    Cpf = order.SeparatedByEmployee.Cpf,
                } : null,
                FinalizedAt = order.FinalizedAt,
                FinalizedByAccountId = order.FinalizedByAccountId,
                FinalizedByAccount = order.FinalizedByAccount != null ? new AppUser
                {
                    Id = order.FinalizedByAccount.Id,
                    UserName = order.FinalizedByAccount.UserName,
                } : null,
                FinalizedByEmployeeId = order.FinalizedByEmployeeId,
                FinalizedByEmployee = order.FinalizedByEmployee != null ? new EmployeeDto
                {
                    Id = order.FinalizedByEmployee.Id,
                    Name = order.FinalizedByEmployee.Name,
                    Cpf = order.FinalizedByEmployee.Cpf,
                } : null,
                OrderStatusId = order.OrderStatusId,
                OrderStatus = order.OrderStatus != null ? new OrderStatus
                {
                    Id = order.OrderStatus.Id,
                    Description = order.OrderStatus.Description,
                } : null,

                OrderItems = order.OrderItems?.Select(item => new OrderItemResponseDto
                {
                    Id = item.Id,
                    RequestedQuantity = item.RequestedQuantity,
                    ApprovedQuantity = item.ApprovedQuantity,
                    ActualQuantity = item.ActualQuantity,
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Product = item.Product != null ? new ProductDto
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        DosageForm = item.Product.DosageForm,
                        Category = item.Product.Category,
                    } : null,
                }).ToList() ?? new List<OrderItemResponseDto>()
            }).ToList();

            return Ok(new ApiResponse<List<OrderResponseDto>>(StatusCodes.Status200OK, ApiMessages.MsgOrdersFoundSuccessfully, orderResponseDtos));
        }

        [HttpPut]
        [Route("approve/{id:int}")]
        public async Task<IActionResult> ApproveOrder([FromRoute] int id, [FromBody] ApproveOrderRequestDto approvalDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));
            }

            var orderToApprove = await _orderRepo.GetByIdAsync(id);
            if (orderToApprove == null)
                return NotFound(new ApiResponse<Order>(StatusCodes.Status404NotFound, ApiMessages.MsgOrderNotFound, null!));

            var approvedByEmployee = await _dbContext.Employee.FindAsync(approvalDto.ApprovedByEmployeeId);
            if (approvedByEmployee == null)
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.MsgEmployeeInvalid, null!));

            var approvedByAccount = await _userManager.FindByIdAsync(approvalDto.ApprovedByAccountId.ToString());
            if (approvedByAccount == null)
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));

            if (orderToApprove.OrderStatusId != (int)OrderStatusEnum.Pending)
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.MsgOrderCannotBeApprovedInItsCurrentStatus, null!));

            var status = await _dbContext.OrderStatus.FindAsync(approvalDto.OrderStatusId);
            if (status == null)
                return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, ApiMessages.MsgOrderStatusInvalid, null!));

            orderToApprove.OrderStatusId = status.Id;
            orderToApprove.ApprovedAt = DateTime.UtcNow;
            orderToApprove.ApprovedByEmployeeId = approvalDto.ApprovedByEmployeeId;
            orderToApprove.ApprovedByAccountId = approvalDto.ApprovedByAccountId;

            foreach (var itemApprovalDto in approvalDto.OrderItemsApproval)
            {
                var orderItem = orderToApprove.OrderItems?.FirstOrDefault(oi => oi.Id == itemApprovalDto.OrderItemId);
                if (orderItem == null)
                {
                    return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, $"Order item with ID {itemApprovalDto.OrderItemId} not found in this order.", null!));
                }


                if (itemApprovalDto.ApprovedQuantity > orderItem.RequestedQuantity)
                {
                    return BadRequest(new ApiResponse<Order>(StatusCodes.Status400BadRequest, $"Approved quantity for item {itemApprovalDto.OrderItemId} cannot exceed requested quantity ({orderItem.RequestedQuantity}).", null!));
                }

                orderItem.ApprovedQuantity = itemApprovalDto.ApprovedQuantity;
            }

            await _orderRepo.UpdateAsync(orderToApprove);

            var response = await _orderRepo.GetByIdAsync(orderToApprove.Id);
            return Ok(new ApiResponse<Order>(StatusCodes.Status200OK, ApiMessages.MsgOrderApprovedSuccessfully, response!));
        }
    }
}
