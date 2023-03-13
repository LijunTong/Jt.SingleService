using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Core.Tables
{
   [Table("action")]
    public class Action : BaseEntity
    {
        	[Column("id")]
        	public string Id { get; set; }
        	[Column("controller")]
        	public string Controller { get; set; }
        	[Column("name")]
        	public string Name { get; set; }
        	[Column("text")]
        	public string Text { get; set; }
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