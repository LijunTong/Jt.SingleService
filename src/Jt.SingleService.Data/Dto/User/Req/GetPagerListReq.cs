using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Data.Dto.User.Req
{
    public class GetPagerListReq : PagerReq
    {
        public string UserName { get; set; }

        public override (int Code, string Msg) Vaild()
        {
            return base.Vaild();
        }
    }
}
