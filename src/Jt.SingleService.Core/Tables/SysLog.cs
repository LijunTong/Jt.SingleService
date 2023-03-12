using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Core.Tables
{
   [Table("sys_log")]
    public class SysLog : BaseEntity
    {
        	[Column("id")]
        	public string Id { get; set; }
        	[Column("type")]
        	public Int32 Type { get; set; }
        	[Column("title")]
        	public string Title { get; set; }
        	[Column("content")]
        	public string Content { get; set; }
        	[Column("log_time")]
        	public DateTime LogTime { get; set; }
        	[Column("user_id")]
        	public Int32 UserId { get; set; }
        	[Column("remote_address")]
        	public string RemoteAddress { get; set; }
        	[Column("controller")]
        	public string Controller { get; set; }
        	[Column("action")]
        	public string Action { get; set; }
        	[Column("param")]
        	public string Param { get; set; }
        	[Column("creater")]
        	public string Creater { get; set; }
        	[Column("create_time")]
        	public DateTime CreateTime { get; set; }
        	[Column("updater")]
        	public string Updater { get; set; }
        	[Column("up_time")]
        	public DateTime UpTime { get; set; }
    }
}