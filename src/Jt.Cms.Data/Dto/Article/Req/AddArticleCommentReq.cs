using System.ComponentModel.DataAnnotations;

namespace Jt.Cms.Data
{
    public class AddArticleCommentReq
    {
        [Required(ErrorMessage = "ArticleId不能为空")]
        public string ArticleId { get; set; }

        public string CommentId { get; set; }

        public string UserId { get; set; }

        public string ReplyTo { get; set; }

        [Required(ErrorMessage = "内容不能为空")]
        public string Content { get; set; }

        public string AuthorId { get; set; }

    }
}
