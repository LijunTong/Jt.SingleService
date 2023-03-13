using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class CodeDbMapper : IEntityTypeConfiguration<CodeDb>
    {
        public void Configure(EntityTypeBuilder<CodeDb> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}