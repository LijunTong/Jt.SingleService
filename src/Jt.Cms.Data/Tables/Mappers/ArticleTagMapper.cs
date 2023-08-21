using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ArticleTagMapper : IEntityTypeConfiguration<ArticleTag>
    {
        public void Configure(EntityTypeBuilder<ArticleTag> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Article)
                 .WithMany(x => x.ArticleTags)
                 .HasForeignKey(x => x.ArticleId);

            builder.HasOne(m => m.Tag)
                 .WithMany(x => x.ArticleTags)
                 .HasForeignKey(x => x.TagId);
        }
    }
}