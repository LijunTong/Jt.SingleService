using Jt.SingleService.Core.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jt.SingleService.Core.Tables.Mappers
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}