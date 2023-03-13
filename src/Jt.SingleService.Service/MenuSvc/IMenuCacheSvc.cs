using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Service.MenuSvc
{
    public interface IMenuCacheSvc
    {
        Task SetControllerAsync(List<string> controllers);

        Task<List<string>> GetControllerAsync();
    }
}
