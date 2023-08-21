using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data
{
    public class CodeTempMapper : IEntityTypeConfiguration<CodeTemp>
    {
        public void Configure(EntityTypeBuilder<CodeTemp> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}