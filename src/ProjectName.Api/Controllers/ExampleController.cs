using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Requests;
using ProjectName.Database.Abstractions.Entities;
using ProjectName.Domain.ExampleEntities.Commands;
using ProjectName.Domain.ExampleEntities.Queries;

namespace ProjectName.Api.Controllers
{
    [ApiController]
    [Route("api/v1/example")]
    public class ExampleController : BaseController
    {
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets an ExampleEntity by id
        /// </summary>
        /// <returns>An ExampleEntity <see cref="ExampleEntity"/></returns>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExampleEntity))]
        public async Task<IActionResult> GetExampleEntity(Guid id)
        {
            var exampleEntity = await Mediator.Send(new GetExampleEntityByIdQuery(id));
            if (exampleEntity is null) 
                return NotFound();

            return Ok(exampleEntity);
        }

        /// <summary>
        /// Creates an ExampleEntity
        /// </summary>
        /// <returns>Id of created ExampleEntity</returns>
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<IActionResult> CreateExampleEntity(CreateExampleEntityRequest request)
        {
            var command = new AddExampleEntityCommand()
            {
                ExampleValue1 = request.ExampleValue1,
                ExampleValue2 = request.ExampleValue2,
                ExampleValue3 = request.ExampleValue3,
            };

            var result = await Mediator.Send(command);
            if (result == Guid.Empty)
                return BadRequest();

            return Ok(result);
        }
    }
}