using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ArticleReadMapper : IEntityTypeConfiguration<ArticleRead>
    {
        public void Configure(EntityTypeBuilder<ArticleRead> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Article)
                 .WithMany(x => x.ArticleReads)
                 .HasForeignKey(x => x.ArticleId);

            builder.HasOne(m => m.User)
                 .WithMany(x => x.ArticleReads)
                 .HasForeignKey(x => x.UserId);
        }
    }
}