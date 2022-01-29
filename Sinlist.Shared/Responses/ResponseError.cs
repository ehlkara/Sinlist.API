using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinlist.Shared.Responses
{
    public class ResponseError : Exception
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
