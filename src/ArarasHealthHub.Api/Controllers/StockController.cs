using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    // [Authorize]
    public class StockController : ControllerBase
    {
    //     private readonly IStockRepository _stockRepo;

    //     public StockController(IStockRepository stockRepo)
    //     {
    //         _stockRepo = stockRepo;
    //     }

    //     [HttpGet]
    //     [Route("getAll")]
    //     [Authorize]
    //     public async Task<IActionResult> GetAll()
    //     {
    //         var stock = await _stockRepo.GetAllAsync();

    //         if (stock == null || !stock.Any())
    //         {
    //             return NotFound(new ApiResponse<List<Stock>>(StatusCodes.Status404NotFound, ApiMessages.MsgNotStocksFound, null!));
    //         }

    //         return Ok(new ApiResponse<List<Stock>>(StatusCodes.Status200OK, ApiMessages.MsgStocksFoundSuccessfully, stock));
    //     }

    //     [HttpGet]
    //     [Route("getByProductId/{productId:int}")]
    //     [Authorize]
    //     public async Task<IActionResult> GetByProductId([FromRoute] int productId)
    //     {
    //         var stock = await _stockRepo.GetByProductIdAsync(productId);

    //         if (stock == null)
    //         {
    //             return NotFound(new ApiResponse<Stock>(StatusCodes.Status404NotFound, ApiMessages.MsgProductStockFoundSuccessfully, null!));
    //         }

    //         return Ok(new ApiResponse<Stock>(StatusCodes.Status200OK, ApiMessages.MsgProductStockNotFound, stock));
    //     }

    //     [HttpPost("updateInternal/{productId}/{quantity}/{batch}")]
    //     internal IActionResult UpdateStockInternal(int productId, int quantity, string batch)
    //     {
    //         _stockRepo.UpdateStock(productId, quantity, batch);
    //         return Ok();
    //     }
    }
}
