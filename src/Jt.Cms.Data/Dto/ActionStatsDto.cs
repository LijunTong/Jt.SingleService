using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Data.Dto
{
    public class ActionStatsDto
    {
        public string controller { get; set; }
        public string action { get; set; }
        public long count { get; set; }
    }
}
