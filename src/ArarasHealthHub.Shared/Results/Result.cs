using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Shared.Results
{
    public class Result
    {
        public string Message { get; }

        protected Result(string message)
        {
            Message = message;
        }

        public static Result Success(string message = "Operação realizada com sucesso.")
            => new(message);
    }

    public class Result<T> : Result
    {
        public T Data { get; }

        protected Result(T data, string message)
            : base(message)
        {
            Data = data;
        }

        public static Result<T> Success(
            T data,
            string message = "Operação realizada com sucesso.")
            => new(data, message);
    }
}
