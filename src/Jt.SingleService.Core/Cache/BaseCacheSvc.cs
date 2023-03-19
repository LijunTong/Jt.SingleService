namespace Jt.SingleService.Core.Cache
{
    public class BaseCacheSvc : IBaseCacheSvc
    {
        public string MergeKey(params string[] keys)
        {
            return string.Join('_', keys);
        }
    }
}
