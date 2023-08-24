using MediatR;
using ProjectName.Database.Abstractions.Entities;
using ProjectName.Database.Abstractions.Repositories;

namespace ProjectName.Domain.ExampleEntities.Queries
{
    public class GetExampleEntityByIdQuery : IRequest<ExampleEntity?>
    {
        public Guid Id { get; set; }
        public GetExampleEntityByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetExampleEntityByIdHandler : IRequestHandler<GetExampleEntityByIdQuery, ExampleEntity?>
    {
        private readonly IExampleRepository _exampleRepository;

        public GetExampleEntityByIdHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<ExampleEntity?> Handle(GetExampleEntityByIdQuery query, CancellationToken cancellationToken)
        {
            return await _exampleRepository.GetExampleEntityById(query.Id);
        }
    }
}
