using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Dto
{
    public class CustomResponse
    {
        public int State { get; set; }
        public string Message { get; set; }
        public dynamic Custom { get; set; }
    }
   
}
