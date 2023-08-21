using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class ArticleColumnMapper : IEntityTypeConfiguration<ArticleColumn>
    {
        public void Configure(EntityTypeBuilder<ArticleColumn> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Article)
                 .WithMany(x => x.ArticleColumns)
                 .HasForeignKey(x => x.ArticleId);

            builder.HasOne(m => m.Column)
                 .WithMany(x => x.ArticleColumns)
                 .HasForeignKey(x => x.ColumnId);
        }
    }
}