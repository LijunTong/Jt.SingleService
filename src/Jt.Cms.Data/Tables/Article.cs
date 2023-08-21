using System.ComponentModel.DataAnnotations.Schema;

namespace Jt.Cms.Data
{
    [Table("article")]
    public class Article : BaseEntity
    {
        [Column("title")]
        public string Title { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("cover_url")]
        public string CoverUrl { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// ���� 1ͼ�ģ�2��Ƶ
        /// </summary>
        [Column("type")]
        public Int32 Type { get; set; }

        [Column("publish_time")]
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// �������� 1�������˿ɼ���Ĭ�ϣ���2����˿�ɼ���3�����Լ��ɼ�
        /// </summary>
        [Column("public_type")]
        public Int32 PublicType { get; set; }

        /// <summary>
        /// �Ƿ��ö� 0�����ö���1���ö�
        /// </summary>
        [Column("is_top")]
        public Int32 IsTop { get; set; }

        /// <summary>
        /// ״̬��1���ݸ壬2������
        /// </summary>
        [Column("status")]
        public Int32 Status { get; set; }

        public List<ArticleCollect> ArticleCollects { get; set; }

        public List<ArticleColumn> ArticleColumns { get; set; }

        public List<ArticleComment> ArticleComments { get; set; }

        public List<ArticleLike> ArticleLikes { get; set; }

        public List<ArticleRead> ArticleReads { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }

    }
}