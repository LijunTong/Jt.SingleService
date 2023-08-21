using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article_read")]
    public class ArticleRead : BaseEntity
    {

        [Column("article_id")]
        public string ArticleId { get; set; }

        [Column("read_time")]
        public DateTime ReadTime { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        public Article Article { get; set; }

        public User User { get; set; }

    }
}