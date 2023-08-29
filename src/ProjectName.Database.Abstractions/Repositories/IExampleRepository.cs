using ProjectName.Database.Abstractions.Entities;

namespace ProjectName.Database.Abstractions.Repositories
{
    public interface IExampleRepository
    {
        public Task<ExampleEntity?> GetExampleEntityById(Guid id, CancellationToken cancellationToken = default);
        public Task<bool> AddExampleEntity(ExampleEntity exampleEntity, CancellationToken cancellationToken = default);
    }
}
