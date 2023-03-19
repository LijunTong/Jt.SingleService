using Jt.SingleService.Data.Tables.DatabaseEntity;
using Jt.SingleService.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Data.Dto
{
    public class CodeTempParamsDto
    {
        public string CodeSchemeId { get; set; }
        public string TableName { get; set; }
        public string ClassName { get; set; }
        public List<DbFieldInfo> DbFieldInfos { get; set; }
        public List<CodeSchemeDetials> Temps { get; set; }
    }
}
