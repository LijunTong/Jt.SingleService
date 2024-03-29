using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.SingleService.Data
{
    [Table("menu")]
    public class Menu : BaseEntity
    {
        [Column("controller")]
        public string Controller { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("path")]
        public string Path { get; set; }

        [Column("redirect")]
        public string Redirect { get; set; }

        [Column("affix")]
        public Boolean Affix { get; set; }

        [Column("icon")]
        public string Icon { get; set; }

        [Column("hidden")]
        public Boolean Hidden { get; set; }

        [Column("sort_index")]
        public Int32 SortIndex { get; set; }

        [Column("type")]
        public Int16 Type { get; set; }

        [Column("parent_id")]
        public string ParentId { get; set; }

        [NotMapped]
        public List<Menu> Children { get; set; }

        [NotMapped]
        public List<Action> Actions { get; set; }
    }
}