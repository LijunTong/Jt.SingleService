using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Data.Dto
{
    public class UserRoleDto
    {
        public string UserId { get; set; }

        public List<string> RoleIds { get; set; }
    }
}
