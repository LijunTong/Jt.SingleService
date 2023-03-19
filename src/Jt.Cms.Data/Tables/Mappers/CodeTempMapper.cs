using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class CodeTempMapper : IEntityTypeConfiguration<CodeTemp>
    {
        public void Configure(EntityTypeBuilder<CodeTemp> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}