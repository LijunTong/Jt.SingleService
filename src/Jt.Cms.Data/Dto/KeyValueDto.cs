using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Data.Dto
{
    public class KeyValueDto<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
