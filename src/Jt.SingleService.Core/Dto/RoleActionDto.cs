using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Dto
{
    public class RoleActionDto
    {
        public string RoleId { get; set; }
        public List<ActionDto> Actions { get; set; }
    }
    public class ActionDto
    {
        public string Controller { get; set; }
        public string Action { get; set; }

    }
}
