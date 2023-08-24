using Microsoft.EntityFrameworkCore;
using ProjectName.Database.Abstractions.Entities;

namespace ProjectName.Database.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<ExampleEntity> ExampleEntities { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
