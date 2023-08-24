using ProjectName.Database.Abstractions.Entities;
using ProjectName.Domain.ExampleEntities.Commands;

namespace ProjectName.Domain.ExampleEntities.Mapping
{
    public static class ExampleEntityExtensions
    {
        public static ExampleEntity ToExampleEntity(this AddExampleEntityCommand command)
        {
            return new ExampleEntity()
            {
                Id = command.Id,
                ExampleValue1 = command.ExampleValue1,
                ExampleValue2 = command.ExampleValue2,
                ExampleValue3 = command.ExampleValue3,
            };
        }
    }
}
