using System.ComponentModel.DataAnnotations;

namespace Jt.Cms.Data
{
    public class PublishArticleReq
    {
        [Required(ErrorMessage = "ArticleId 不能为空")]
        public string ArticleId { get; set; }

        public string UserId { get; set; }
    }
}
