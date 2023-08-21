using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    public class BaseEntity
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("creater")]
        public string Creater { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("updater")]
        public string Updater { get; set; }

        [Column("up_time")]
        public DateTime UpTime { get; set; }

        [Column("is_del")]
        public int IsDel { get; set; }

    }
}
