using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models;

namespace SWCLMS.Models
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
        public int Count { get; set; }
    }
}
