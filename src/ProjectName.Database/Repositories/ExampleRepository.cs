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

        public async Task<bool> AddExampleEntity(ExampleEntity exampleEntity)
        {
            await _context.ExampleEntities.AddAsync(exampleEntity);
            return true;
        }

        public async Task<ExampleEntity?> GetExampleEntityById(Guid id)
        {
            return await _context.ExampleEntities.FindAsync(id);
        }
    }
}
