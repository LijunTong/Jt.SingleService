using System.ComponentModel.DataAnnotations;

namespace Jt.Cms.Data
{
    public class AddArticleReq
    {
        public string ArticleId { get; set; }

        [Required(ErrorMessage = "标题不能为空")]
        public string Title { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        public string Content { get; set; }

        public int Type { get; set; }

        public string UserId { get; set; }

        public int IsTop { get; set; }

        public int Status { get; set; }

        public int PublicType { get; set; }
    }
}
