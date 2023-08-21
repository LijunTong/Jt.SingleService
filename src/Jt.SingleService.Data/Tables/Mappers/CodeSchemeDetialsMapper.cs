using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data
{
    public class CodeSchemeDetialsMapper : IEntityTypeConfiguration<CodeSchemeDetials>
    {
        public void Configure(EntityTypeBuilder<CodeSchemeDetials> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.CodeTemp)
                 .WithMany(x => x.CodeSchemeDetials)
                 .HasForeignKey(x => x.TempId);

            builder.HasOne(m => m.CodeGenScheme)
                 .WithMany(x => x.CodeSchemeDetials)
                 .HasForeignKey(x => x.GenSchemeId);
        }
    }
}