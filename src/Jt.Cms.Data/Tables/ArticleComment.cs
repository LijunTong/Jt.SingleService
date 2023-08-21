using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article_comment")]
    public class ArticleComment : BaseEntity
    {
        [Column("article_id")]
        public string ArticleId { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("publish_time")]
        public DateTime PublishTime { get; set; }

        [Column("parent_id")]
        public string ParentId { get; set; }

        [Column("reply_to")]
        public string ReplyTo { get; set; }

        [Column("is_top")]
        public Int32 IsTop { get; set; }

        [Column("is_author")]
        public Int32 IsAuthor { get; set; }

        public Article Article { get; set; }

        public User User { get; set; }

        public List<CommentLike> CommentLikes { get; set; }

    }
}