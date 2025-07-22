using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Core
{
    public class ApiResponse<T> : ApiResponseBase
    {
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int statusCode, string message, T? data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            Success = true;
        }

        public ApiResponse(int statusCode, string message, bool success)
        {
            StatusCode = statusCode;
            Message = message;
            Success = success;
        }

        public ApiResponse(int statusCode, string message, Dictionary<string, List<string>> errors, bool success)
        {
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
            Success = success;
        }
    }
}
