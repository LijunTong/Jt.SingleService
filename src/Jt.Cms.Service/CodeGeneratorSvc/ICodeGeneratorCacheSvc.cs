using Jt.Cms.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Service.CodeGeneratorSvc
{
    public interface ICodeGeneratorCacheSvc : IBaseCacheSvc
    {
        //代码生成工具
        Task SetDbTypeAsync(string userName, string dbType, TimeSpan expiresIn);

        Task<string> GetDbTypeAsync(string userName);

        Task SetDbConnectStrAsync(string userName, string connectStr, TimeSpan expiresIn);

        Task<string> GetDbConnectStrAsync(string userName);
    }
}
