using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Data.Dto
{
    public class RoleActionDto
    {
        public string RoleId { get; set; }
        public List<ActionDto> Actions { get; set; }

        public string UserId { get; set; }
    }
    public class ActionDto
    {
        public string Controller { get; set; }
        public string Action { get; set; }

    }
}
