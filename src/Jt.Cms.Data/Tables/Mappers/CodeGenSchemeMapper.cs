using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class CodeGenSchemeMapper : IEntityTypeConfiguration<CodeGenScheme>
    {
        public void Configure(EntityTypeBuilder<CodeGenScheme> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}