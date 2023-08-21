using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data
{
    public class CodeDbMapper : IEntityTypeConfiguration<CodeDb>
    {
        public void Configure(EntityTypeBuilder<CodeDb> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}