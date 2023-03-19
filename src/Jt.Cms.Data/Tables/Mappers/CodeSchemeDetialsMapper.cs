using Jt.Cms.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.Cms.Data.Tables.Mappers
{
    public class CodeSchemeDetialsMapper : IEntityTypeConfiguration<CodeSchemeDetials>
    {
        public void Configure(EntityTypeBuilder<CodeSchemeDetials> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}