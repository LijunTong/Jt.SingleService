using JT.Framework.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Cache
{
    public class BaseCacheService : IBaseCacheService
    {
        public string MergeKey(params string[] keys)
        {
            return string.Join('_', keys);
        }
    }
}
