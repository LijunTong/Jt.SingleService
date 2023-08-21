using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data
{
    [Table("action")]
    public class Action : BaseEntity
    {
        [Column("controller")]
        public string Controller { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("text")]
        public string Text { get; set; }
    }
}