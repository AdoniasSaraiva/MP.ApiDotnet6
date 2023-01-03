using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(x => x.Id);
            builder.Property(u => u.Id).HasColumnName("UserId");
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.Property(u => u.Password).HasColumnName("PassWord");

            builder.HasMany(x => x.UserPermissions).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        }
    }
}
