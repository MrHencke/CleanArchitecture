using MediatR;
using ProjectName.Database.Abstractions.Repositories;
using ProjectName.Domain.ExampleEntities.Mapping;

namespace ProjectName.Domain.ExampleEntities.Commands
{
    public class AddExampleEntityCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string ExampleValue1 { get; set; }
        public int ExampleValue2 { get; set; }
        public bool ExampleValue3 { get; set; }
    }

    public class AddExampleEntityHandler : IRequestHandler<AddExampleEntityCommand, bool>
    {
        private readonly IExampleRepository _exampleRepository;

        public AddExampleEntityHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<bool> Handle(AddExampleEntityCommand command, CancellationToken cancellationToken)
        {
            return await _exampleRepository.AddExampleEntity(command.ToExampleEntity());
        }
    }
}
