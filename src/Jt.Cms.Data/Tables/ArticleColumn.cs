using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article_column")]
    public class ArticleColumn : BaseEntity
    {

        [Column("article_id")]
        public string ArticleId { get; set; }

        [Column("column_id")]
        public string ColumnId { get; set; }

        public Article Article { get; set; }

        public Column Column { get; set; }

    }
}