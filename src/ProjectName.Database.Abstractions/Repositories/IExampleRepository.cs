using ProjectName.Database.Abstractions.Entities;

namespace ProjectName.Database.Abstractions.Repositories
{
    public interface IExampleRepository
    {
        public Task<ExampleEntity?> GetExampleEntityById(Guid id);
        public Task<bool> AddExampleEntity(ExampleEntity exampleEntity);
    }
}
