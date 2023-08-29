using MediatR;
using ProjectName.Database.Abstractions.Repositories;
using ProjectName.Domain.ExampleEntities.Mapping;

namespace ProjectName.Domain.ExampleEntities.Commands
{
    public class AddExampleEntityCommand : IRequest<Guid>
    {
        public string ExampleValue1 { get; set; }
        public int ExampleValue2 { get; set; }
        public bool ExampleValue3 { get; set; }
    }

    public class AddExampleEntityHandler : IRequestHandler<AddExampleEntityCommand, Guid>
    {
        private readonly IExampleRepository _exampleRepository;

        public AddExampleEntityHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<Guid> Handle(AddExampleEntityCommand command, CancellationToken cancellationToken)
        {
            var exampleEntity = command.ToExampleEntity();
            var result = await _exampleRepository.AddExampleEntity(exampleEntity, cancellationToken);
            if(result)
                return exampleEntity.Id;

            return Guid.Empty;
        }
    }
}
