using Jt.SingleService.Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Jwt
{
    public class JwtUser
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public List<Role> Roles { get; set; }
    }
}
