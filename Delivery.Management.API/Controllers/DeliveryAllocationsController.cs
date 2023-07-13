using Delivery.Management.Application.DTOs.DeliveryAllocation;
using Delivery.Management.Application.DTOs.DeliveryType;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Commands;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Queries;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Commands;
using Delivery.Management.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Delivery.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DeliveryAllocationsController : ControllerBase
    {
        public readonly IMediator _mediator;
        public DeliveryAllocationsController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        // GET: api/<DeliveryAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<DeliveryAllocationDto>>> Get()
        {
            var deliveryAllocations = await _mediator.Send(new GetDeliveryAllocationListRequest());
            return Ok(deliveryAllocations);
        } 

        // GET api/<DeliveryAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryAllocationDto>> Get(int id)
        {
            var deliveryAllocation = await _mediator.Send(new GetDeliveryAllocationDetailRequest { Id = id });
            return Ok(deliveryAllocation);
        }

        // POST api/<DeliveryAllocationsController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDeliveryAllocationDto deliveryAllocation)
        {
            var command = new CreateDeliveryAllocationCommand { DeliveryAllocationDto = deliveryAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DeliveryAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] DeliveryAllocationDto deliveryAllocation)
        {
            var command = new UpdateDeliveryAllocationCommand { DeliveryAllocationDto= deliveryAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<DeliveryAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteDeliveryAllocationCommand {  Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
