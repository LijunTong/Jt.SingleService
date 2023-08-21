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
        /// 类型 1图文，2视频
        /// </summary>
        [Column("type")]
        public Int32 Type { get; set; }

        [Column("publish_time")]
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 公开类型 1：所有人可见（默认），2：粉丝可见，3：仅自己可见
        /// </summary>
        [Column("public_type")]
        public Int32 PublicType { get; set; }

        /// <summary>
        /// 是否置顶 0：不置顶，1：置顶
        /// </summary>
        [Column("is_top")]
        public Int32 IsTop { get; set; }

        /// <summary>
        /// 状态：1：草稿，2：发布
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