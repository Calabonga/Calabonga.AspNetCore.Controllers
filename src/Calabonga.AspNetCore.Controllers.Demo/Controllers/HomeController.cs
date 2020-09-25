using System;
using System.Threading.Tasks;

using Calabonga.AspNetCore.Controllers.Demo.Controllers.Commands;
using Calabonga.AspNetCore.Controllers.Demo.Controllers.Queries;
using Calabonga.AspNetCore.Controllers.Demo.ViewModels;
using Calabonga.Microservices.Core.QueryParams;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Calabonga.AspNetCore.Controllers.Demo.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpDelete("[action]/{id:guid}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            return Ok(await _mediator.Send(new PersonDeleteItemQuery(id)));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> PutItem([FromQuery] Guid id, [FromBody] PersonUpdateViewModel model)
        {
            return Ok(await _mediator.Send(new PersonPutItemQuery(model)));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PostItem(PersonCreateViewModel model)
        {
            return Ok(await _mediator.Send(new PersonPostItemQuery(model)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPaged([FromQuery] PagedListQueryParams queryParams)
        {
            return Ok(await _mediator.Send(new PersonPagedQuery(queryParams)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(string id = "f619eca2-8d99-e180-45a5-15c91f80b703")
        {
            return Ok(await _mediator.Send(new PersonByIdQuery(Guid.Parse(id))));
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUpdateViewModel(string id = "f619eca2-8d99-e180-45a5-15c91f80b703")
        {
            return Ok(await _mediator.Send(new PersonUpdateViewModelQuery(Guid.Parse(id))));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCreateViewModel()
        {
            return Ok(await _mediator.Send(new PersonCreateViewModelQuery()));
        }


    }
}
