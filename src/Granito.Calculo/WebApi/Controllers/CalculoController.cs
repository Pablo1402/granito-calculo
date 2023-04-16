using Domain.Commands;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CalculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("calcula-juros")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CalculoResponseDto))]
        public async Task<IActionResult> Index([FromBody] CalculaJurosCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
