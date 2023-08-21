using System.ComponentModel.DataAnnotations;

namespace Jt.Cms.Data
{
    public class PagerReq
    {
        [Range(0, int.MaxValue, ErrorMessage = "Page 应该大于0")]
        public int Page { get; set; }

        public int Size { get; set; }

        public int Total { set; get; }

        public object Data { get; set; }
    }
}
