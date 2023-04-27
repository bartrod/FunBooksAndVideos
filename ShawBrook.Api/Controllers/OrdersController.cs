using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShawBrook.Application.Commands;

namespace ShawBrook.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreatePurchaseOrderCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(
             actionName: nameof(CreateOrder),
             routeValues: new { id = result.Id },
             value: result);
        }
    }
}
