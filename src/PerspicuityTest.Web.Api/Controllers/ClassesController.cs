using MediatR;
using Microsoft.AspNetCore.Mvc;
using PerspicuityTest.Core.Commands.Classes;
using PerspicuityTest.Core.Dtos;
using PerspicuityTest.Core.Queries.Classes;
using PerspicuityTest.Core.Utilities.Exceptions;
using System.Net;

namespace PerspicuityTest.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Class), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] Class @class)
        {
            var newClass = await _mediator.Send(new CreateClassCommand(@class));
            var resourceUri = new Uri($"{Request.Scheme}://{Request.Host}/api/classes/{newClass.Id}");

            return Created(resourceUri, newClass);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Class>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var classes = await _mediator.Send(new GetAllClassesQuery());

            return Ok(classes);
        }

        [HttpGet("{classId}")]
        [ProducesResponseType(typeof(Class), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute]Guid classId)
        {
            var @class = await _mediator.Send(new GetClassByIdQuery(classId));

            if (@class == null) return NotFound();
            return Ok(@class);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Class), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put([FromForm]Class @class)
        {
            try
            {
                await _mediator.Send(new UpdateClassCommand(@class));
                return Ok(@class);
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{classId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute]Guid classId)
        {
            try
            {
                await _mediator.Send(new DeleteClassCommand(classId));
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
