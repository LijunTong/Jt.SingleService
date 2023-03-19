using Jt.SingleService.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Data.Tables.Mappers
{
    public class CodeSchemeDetialsMapper : IEntityTypeConfiguration<CodeSchemeDetials>
    {
        public void Configure(EntityTypeBuilder<CodeSchemeDetials> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}