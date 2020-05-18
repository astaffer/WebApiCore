using System;
using System.Collections.Generic;
using System.Text;

namespace WAC.Models.Responses
{
    public class BaseResponse
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
