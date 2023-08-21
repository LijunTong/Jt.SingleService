namespace Jt.Cms.Core
{
    public class BaseCacheSvc : IBaseCacheSvc
    {
        public string MergeKey(params string[] keys)
        {
            return string.Join('_', keys);
        }
    }
}
