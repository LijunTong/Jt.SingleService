using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article_collect")]
    public class ArticleCollect : BaseEntity
    {
        [Column("article_id")]
        public string ArticleId { get; set; }

        [Column("collect_time")]
        public DateTime CollectTime { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// �Ƿ��ղ� 0�����ǣ�1����
        /// </summary>
        [Column("is_collect")]
        public Int32 IsCollect { get; set; }

        public Article Article { get; set; }

        public User User { get; set; }

    }
}