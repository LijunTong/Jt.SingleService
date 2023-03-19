using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Models
{
    public class PagerReq
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public int Total { set; get; }

        public object Data { get; set; }

    }
}
