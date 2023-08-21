namespace Jt.SingleService.Data
{
    public class PagerOutput<T>
    {
        public int Total { set; get; }

        public List<T> Data { get; set; }
    }
}
