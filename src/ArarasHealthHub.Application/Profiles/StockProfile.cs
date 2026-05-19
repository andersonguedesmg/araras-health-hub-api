using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Application.Features.Stocks.Responses;
using ArarasHealthHub.Domain.Entities;

using AutoMapper;

namespace ArarasHealthHub.Application.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ConstructUsing(src => new ProductResponse(
                    src.Id,
                    src.Name,
                    src.Description,
                    src.MainCategoryId,
                    src.MainCategory != null ? src.MainCategory.Name : string.Empty,
                    src.SubCategoryId,
                    src.SubCategory != null ? src.SubCategory.Name : string.Empty,
                    src.PackagingTypeId,
                    src.PackagingType != null ? src.PackagingType.Name : string.Empty,
                    src.CreatedOn,
                    src.UpdatedOn ?? src.CreatedOn,
                    src.IsActive
                ));

            CreateMap<Stock, StockResponse>()
                .ConstructUsing(src => new StockResponse(
                    src.Id,
                    src.ProductId,
                    new ProductResponse(
                        src.Product.Id,
                        src.Product.Name,
                        src.Product.Description,
                        src.Product.MainCategoryId,
                        src.Product.MainCategory != null ? src.Product.MainCategory.Name : string.Empty,
                        src.Product.SubCategoryId,
                        src.Product.SubCategory != null ? src.Product.SubCategory.Name : string.Empty,
                        src.Product.PackagingTypeId,
                        src.Product.PackagingType != null ? src.Product.PackagingType.Name : string.Empty,
                        src.Product.CreatedOn,
                        src.Product.UpdatedOn ?? src.Product.CreatedOn,
                        src.Product.IsActive
                    ),
                    src.CurrentQuantity,
                    src.ReservedQuantity,
                    src.AvailableQuantity,
                    src.MinQuantity,
                    src.StockCost != null ? src.StockCost.AverageUnitCost : 0,
                    src.CreatedOn,
                    src.UpdatedOn
                ));
        }
    }
}
