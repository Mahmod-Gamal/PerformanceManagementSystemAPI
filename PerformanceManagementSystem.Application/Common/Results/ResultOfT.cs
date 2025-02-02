using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceManagementSystem.Application.Common.Results
{
    public class Result<T> : Result
    {
        protected internal Result(T value, bool success, string error, Status status)
            : base(success, error, status)
        {
            Value = value;
        }
        public T Value { get; set; }


        public static Result<T> BadRequest(string message)
        {
            return new Result<T>(default, false, message, Status.BadRequest);
        }

        public static Result<T> NotFound(string message)
        {
            return new Result<T>(default, false, message, Status.NotFound);
        }

        public static Result<T> UnAuthorized(string message)
        {
            return new Result<T>(default, false, message, Status.UnAuthorized);
        }

        public static Result<T> Fail(string message, Status status)
        {
            return new Result<T>(default, false, message, status);
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value, true, string.Empty, Status.OK);
        }
    }
}
