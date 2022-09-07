using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{
    public class SAM_UserAccountMap : IEntityTypeConfiguration<SAM_UserAccount>
    {
        public void Configure(EntityTypeBuilder<SAM_UserAccount> entity)
        {
            entity.HasKey(e => e.AccountID);

            entity.ToTable("SAM_UserAccount");

            entity.Property(e => e.AccountID).HasColumnName("AccountID");
            entity.Property(e => e.AccountName)
                .HasColumnName("AccountName")
                .HasMaxLength(50);

            entity.Property(e => e.AccPwd)
                .HasColumnName("AccPwd")
                .HasMaxLength(100);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.CreatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);

            entity.Property(e => e.IsActivated)
                .HasColumnName("IsActivated")
                .HasColumnType("bit");

            entity.Property(e => e.AccountEmail).HasMaxLength(100);

            entity.Property(e => e.RecoveryEmail).HasMaxLength(100);

            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedUser)
                .HasMaxLength(125)
                .IsUnicode(false);

            entity.Property(e => e.CustomerID);

            entity.Property(e => e.IsBlocked)
                  .HasColumnName("IsBlocked")
                  .HasColumnType("bit");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.SamUserAccount)
                .HasForeignKey(d => d.CustomerID);
        }
    }
}
