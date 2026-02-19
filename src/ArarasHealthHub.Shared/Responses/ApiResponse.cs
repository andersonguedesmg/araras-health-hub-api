using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Responses
{
    public sealed class ApiResponse<T> : ApiResponseBase
    {
        public T? Data { get; }

        private ApiResponse(
            int statusCode,
            string message,
            bool success,
            T? data = default,
            IReadOnlyDictionary<string, IReadOnlyList<string>>? errors = null)
        {
            StatusCode = statusCode;
            Message = message;
            Success = success;
            Data = data;
            Errors = errors;
        }

        public static ApiResponse<T> SuccessResponse(
            int statusCode,
            string message,
            T? data = default)
        {
            return new ApiResponse<T>(
                statusCode,
                message,
                success: true,
                data: data
            );
        }

        public static ApiResponse<T> FailureResponse(
            int statusCode,
            string message)
        {
            return new ApiResponse<T>(
                statusCode,
                message,
                success: false
            );
        }

        public static ApiResponse<T> FailureResponse(
            int statusCode,
            string message,
            IReadOnlyDictionary<string, IReadOnlyList<string>> errors)
        {
            return new ApiResponse<T>(
                statusCode,
                message,
                success: false,
                errors: errors
            );
        }

        public static ApiResponse<T> FailureResponse(
            int statusCode,
            string message,
            IEnumerable<string> errors)
        {
            return new ApiResponse<T>(
                statusCode,
                message,
                success: false,
                errors: new Dictionary<string, IReadOnlyList<string>>
                {
                    ["GeneralErrors"] = errors.ToList()
                }
            );
        }
    }
}
