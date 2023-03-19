using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class CodeDbMapper : IEntityTypeConfiguration<CodeDb>
    {
        public void Configure(EntityTypeBuilder<CodeDb> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}