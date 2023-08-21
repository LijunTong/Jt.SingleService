using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article_like")]
    public class ArticleLike : BaseEntity
    {

        [Column("article_id")]
        public string ArticleId { get; set; }

        [Column("like_time")]
        public DateTime LikeTime { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("is_like")]
        public Int32 IsLike { get; set; }

        public Article Article { get; set; }

        public User User { get; set; }

    }
}