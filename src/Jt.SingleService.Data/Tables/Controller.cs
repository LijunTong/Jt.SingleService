using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data
{
    [Table("controller")]
    public class Controller : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
    }
}