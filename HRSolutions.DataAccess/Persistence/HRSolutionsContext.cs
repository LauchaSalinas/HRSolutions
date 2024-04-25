using HRSolutions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRSolutions.DataAccess.Persistence
{
    public class HRSolutionsContext : DbContext
    {
        public HRSolutionsContext(DbContextOptions<HRSolutionsContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // I prefer to hide Persistence information about relational database to the rest of the layers, so Primary Key Id is configured via Fluent API and not in the domain models.
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IBaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddProperty("Id", typeof(int));
                    entityType.FindProperty("Id")!.ValueGenerated = ValueGenerated.OnAdd;
                    entityType.FindProperty("Id")!.SetColumnName("Id");
                }
            }
                modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeId)
                    .HasMaxLength(10)
                    .IsRequired();
            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeId)
                .IsUnique();


            base.OnModelCreating(modelBuilder);

        }
    }
}
