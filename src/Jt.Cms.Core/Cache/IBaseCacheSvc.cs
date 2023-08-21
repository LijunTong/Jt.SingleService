namespace Jt.Cms.Core
{
    public interface IBaseCacheSvc
    {
        string MergeKey(params string[] keys);
    }
}
