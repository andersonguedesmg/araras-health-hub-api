using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Shared.Core.Pagination
{
    public class PagedResponse<T> : ApiResponseBase
    {
        public ApiResponse<IReadOnlyList<T>> Response { get; }

        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        private PagedResponse(
            ApiResponse<IReadOnlyList<T>> response,
            int pageNumber,
            int pageSize,
            int totalCount)
        {
            Response = response;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public static PagedResponse<T> SuccessPaged(
            int pageNumber,
            int pageSize,
            int totalCount,
            IReadOnlyList<T> data)
        {
            return new PagedResponse<T>(
                ApiResponse<IReadOnlyList<T>>.SuccessResponse(
                    StatusCodes.Status200OK,
                    ApiMessages.OperationSuccessful,
                    data),
                pageNumber,
                pageSize,
                totalCount);
        }
    }
}
