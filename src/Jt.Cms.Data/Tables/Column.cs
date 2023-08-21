using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("column")]
    public class Column : BaseEntity
    {

        [Column("name")]
        public string Name { get; set; }

        public List<ArticleColumn> ArticleColumns { get; set; }

    }
}