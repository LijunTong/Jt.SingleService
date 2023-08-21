using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ArticleCollectMapper : IEntityTypeConfiguration<ArticleCollect>
    {
        public void Configure(EntityTypeBuilder<ArticleCollect> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Article)
                .WithMany(x => x.ArticleCollects)
                .HasForeignKey(x => x.ArticleId);

            builder.HasOne(m => m.User)
                .WithMany(u => u.ArticleCollects)
                .HasForeignKey(m => m.UserId);
        }
    }
}