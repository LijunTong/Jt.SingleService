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

        public virtual (int Code, string Msg) Vaild()
        {
            if (Page <= 0)
            {
                return (ApiReturnCode.ParamError, "Page 应该大于0");
            }
            return (ApiReturnCode.Succeed, "");
        }
    }
}
