using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("tag")]
    public class Tag : BaseEntity
    {

        [Column("name")]
        public string Name { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }

    }
}