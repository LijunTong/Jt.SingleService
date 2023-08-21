using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("sys_log")]
    public class SysLog : BaseEntity
    {
        [Column("type")]
        public Int32 Type { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("content")]
        public string Content { get; set; }
        [Column("log_time")]
        public DateTime LogTime { get; set; }
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("remote_address")]
        public string RemoteAddress { get; set; }
        [Column("controller")]
        public string Controller { get; set; }
        [Column("action")]
        public string Action { get; set; }
        [Column("param")]
        public string Param { get; set; }
    }
}