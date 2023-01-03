using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotnet6.Infra.Data.Maps
{
    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("PermissionUser");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PermissionUserId").ValueGeneratedOnAdd();
            builder.Property(x => x.UserId).HasColumnName("UserId"); 
            builder.Property(x => x.PermissionId).HasColumnName("PermissionId");

            builder.HasOne(x => x.Permission).WithMany(p => p.UserPermissions);
            builder.HasOne(x => x.User).WithMany(p => p.UserPermissions);
        }
    }
}
