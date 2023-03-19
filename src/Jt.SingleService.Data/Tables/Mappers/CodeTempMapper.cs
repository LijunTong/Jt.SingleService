using Jt.SingleService.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data.Tables.Mappers
{
    public class CodeTempMapper : IEntityTypeConfiguration<CodeTemp>
    {
        public void Configure(EntityTypeBuilder<CodeTemp> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}