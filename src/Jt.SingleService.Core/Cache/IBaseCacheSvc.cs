using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Cache
{
    public interface IBaseCacheSvc
    {
        string MergeKey(params string [] keys);
    }
}
