using Jt.Common.Tool.DI;
using Jt.Common.Tool.Helper;

namespace Jt.SingleService.Service
{
    public class IDSvc : IIDSvc, ISingletonDIInterface
    {
        private static readonly SnowflakeHelper _snowflake;

        static IDSvc()
        {
            _snowflake = new SnowflakeHelper();
        }

        public string NextId()
        {
            return _snowflake.NextId().ToString();
        }

        public long LongNextId()
        {
            return _snowflake.NextId();
        }
    }
}
