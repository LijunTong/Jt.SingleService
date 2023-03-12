using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.Framework.Core.IService
{
    public interface IMenuCacheSvc
    {
        void SetController(List<string> controllers);
        List<string> GetController();
    }
}
