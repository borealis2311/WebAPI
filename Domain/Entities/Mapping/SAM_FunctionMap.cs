using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mapping
{
    public class SAM_FunctionMap : IEntityTypeConfiguration<SAM_Function>
    {
        public void Configure(EntityTypeBuilder<SAM_Function> entity)
        {
            entity.HasKey(e => e.FuncID);

            entity.ToTable("SAM_Function");
            entity.Property(e => e.FuncID).HasColumnName("FuncID");

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

            entity.Property(e => e.FuncCode)
                .HasMaxLength(50);

            entity.Property(e => e.FuncDesc)
                .HasMaxLength(50);

            entity.Property(e => e.URL)
                .HasMaxLength(250);

            entity.Property(e => e.Icon)
                .HasMaxLength(20);

            entity.Property(e => e.OrderNo);

            entity.Property(e => e.ModuleID);

            entity.HasOne(d => d.Module)
                  .WithMany(p => p.SamFunction)
                  .HasForeignKey(d => d.ModuleID);

        }
    }
}
