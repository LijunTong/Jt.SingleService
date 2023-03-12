using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class CodeGenSchemeMapper : IEntityTypeConfiguration<CodeGenScheme>
    {
        public void Configure(EntityTypeBuilder<CodeGenScheme> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}