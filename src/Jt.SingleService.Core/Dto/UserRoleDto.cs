using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Dto
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}
