using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("comment_like")]
    public class CommentLike : BaseEntity
    {

        [Column("comment_id")]
        public string CommentId { get; set; }

        [Column("like_time")]
        public DateTime LikeTime { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("is_like")]
        public Int32 IsLike { get; set; }

        [Column("is_author")]
        public Int32 IsAuthor { get; set; }

        public ArticleComment ArticleComment { get; set; }

        public User User { get; set; }
    }
}