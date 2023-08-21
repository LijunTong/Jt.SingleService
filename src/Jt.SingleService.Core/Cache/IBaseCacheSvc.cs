namespace Jt.SingleService.Core
{
    public interface IBaseCacheSvc
    {
        string MergeKey(params string[] keys);
    }
}
