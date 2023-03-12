using JT.Framework.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.Framework.Core.IService
{
    public interface ICodeGeneratorCacheSvc : IBaseCacheService
    {
        //代码生成工具
        void SetDbType(string userName, string dbType, TimeSpan expiresIn);
        string GetDbType(string userName);
        void SetDbConnectStr(string userName, string connectStr, TimeSpan expiresIn);
        string GetDbConnectStr(string userName);
    }
}
