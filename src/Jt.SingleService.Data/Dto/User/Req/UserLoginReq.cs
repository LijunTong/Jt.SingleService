using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Data.Dto.User.Req
{
    public class UserLoginReq
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
