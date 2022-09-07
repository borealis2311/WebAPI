using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{
    public class SAM_UserInRoleMap : IEntityTypeConfiguration<SAM_UserInRole>
    {
        public void Configure(EntityTypeBuilder<SAM_UserInRole> entity)
        {
            entity.HasKey(e => e.UID);

            entity.ToTable("SAM_UserInRole");
            entity.Property(e => e.UID).HasColumnName("UID");

            entity.Property(e => e.AccountID).HasColumnName("AccountID");
            entity.Property(e => e.RoleID).HasColumnName("RoleID");
            entity.Property(e => e.ValidDateFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidDateTo).HasColumnType("datetime");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.CreatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);
         
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);

            entity.Property(e => e.IsBlocked)
                  .HasColumnName("IsBlocked")
                  .HasColumnType("bit");

            entity.HasOne(d => d.UserAccount)
                .WithMany(p => p.SamUserInRole)
                .HasForeignKey(d => d.AccountID);

            entity.HasOne(d => d.Role)
                .WithMany(p => p.SamUserInRole)
                .HasForeignKey(d => d.RoleID);
        }
    }
}
