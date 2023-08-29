using Microsoft.EntityFrameworkCore;
using ProjectName.Database.Abstractions;
using ProjectName.Database.Abstractions.Entities;
using ProjectName.Database.Abstractions.Repositories;

namespace ProjectName.Database.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly IApplicationDbContext _context;

        public ExampleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddExampleEntity(ExampleEntity exampleEntity, CancellationToken cancellationToken = default)
        {
            await _context.ExampleEntities.AddAsync(exampleEntity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<ExampleEntity?> GetExampleEntityById(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.ExampleEntities.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
