using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data
{
    public class CodeTempMapper : IEntityTypeConfiguration<CodeTemp>
    {
        public void Configure(EntityTypeBuilder<CodeTemp> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}