using Jt.SingleService.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Data.Dto
{
    public class CodeGenSchemeDto
    {
        public CodeGenScheme CodeGenScheme { get; set; }
        public List<CodeTempDto> Temps { get; set; }

        public string UserId { get; set; }
    }
}
