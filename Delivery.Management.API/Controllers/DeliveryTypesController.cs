using Delivery.Management.Application.DTOs.DeliveryType;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Commands;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Queries;
using Delivery.Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Delivery.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeliveryTypesController : ControllerBase
    {
        public readonly IMediator _mediator;
        public DeliveryTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<DeliveryTypesController>
        [HttpGet]
        public async Task<ActionResult<List<DeliveryTypeDto>>> Get()
        {
            var deliveryTypes = await _mediator.Send(new GetDeliveryTypeListRequest());
            return Ok(deliveryTypes);
        }

        // GET api/<DeliveryTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryTypeDto>> Get(int id)
        {
            var deliveryType = await _mediator.Send(new GetDeliveryTypeDetailRequest { Id = id });
            return Ok(deliveryType);
        }

        // POST api/<DeliveryTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDeliveryTypeDto deliveryType)
        {
            var command = new CreateDeliveryTypeCommand { DeliveryTypeDto = deliveryType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DeliveryTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] DeliveryTypeDto deliveryType)
        {
            var command = new UpdateDeliveryTypeCommand { DeliveryTypeDto = deliveryType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<DeliveryTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteDeliveryTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
