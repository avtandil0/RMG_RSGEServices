using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.BLL.Models
{
    public class GenericResult<T> : Result
    {
        public T Result { get; private set; }

        public GenericResult(bool isSuccess, int code, string message, T result) :
            base(isSuccess, code, message)
        {
            Result = result;
        }

        static public GenericResult<T> SuccessInstance(T result)
        {
            return new GenericResult<T>(true, 1, "Success", result);
        }
    }
}
