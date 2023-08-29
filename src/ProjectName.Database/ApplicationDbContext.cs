using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectName.Abstractions.Common;
using ProjectName.Database.Abstractions;
using ProjectName.Database.Abstractions.Entities;
using ProjectName.Database.Abstractions.Extensions;
using System.Reflection;

namespace ProjectName.Database
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<ExampleEntity> ExampleEntities { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<Auditable> entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now.SetKindUtc();
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.Now.SetKindUtc();
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("app");
            base.OnModelCreating(builder);
        }
    }
}
