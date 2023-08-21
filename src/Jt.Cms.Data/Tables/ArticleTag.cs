using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article_tag")]
    public class ArticleTag : BaseEntity
    {

        [Column("tag_id")]
        public string TagId { get; set; }

        [Column("article_id")]
        public string ArticleId { get; set; }

        public Article Article { get; set; }

        public Tag Tag { get; set; }

    }
}