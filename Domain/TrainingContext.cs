using Domain.Entities.TableClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class TrainingContext: DbContext
    {
        public  TrainingContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<MD_Customer> MD_Customer { get; set; }
        public DbSet<SAM_Module> SAM_Module { get; set; }
        public DbSet<SAM_Function> SAM_Function { get; set; }
        public DbSet<SAM_UserAccount> SAM_UserAccount { get; set; }
        public DbSet<SAM_FuncInRole> SAM_FuncInRole { get; set; }
        public DbSet<SAM_UserInRole> SAM_UserInRole { get; set; }
        public DbSet<SAM_Role> SAM_Role { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingContext).Assembly);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UpdatedDate = DateTime.Now; ;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.Now; ;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
