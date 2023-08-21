namespace Jt.SingleService.Core
{
    public class BaseCacheSvc : IBaseCacheSvc
    {
        public string MergeKey(params string[] keys)
        {
            return string.Join('_', keys);
        }
    }
}
