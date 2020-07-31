using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Http.Response
{
    public class Error
    {
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
