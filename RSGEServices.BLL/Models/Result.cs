using System;
using System.Collections.Generic;
using System.Text;

namespace RSGEServices.BLL.Models
{
    public class Result
    {
        public Result(bool isSuccess, int code, string message)
        {
            IsSuccess = isSuccess;
            Code = code;
            Message = message;
        }

        static private readonly Result successesult = new Result(true, 0, "ოპერაცია წარმატებით დასრულდა");

        static public Result SuccessInstance()
        {
            return successesult;
        }

        public int Code { get; protected set; }
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }
    }
}
