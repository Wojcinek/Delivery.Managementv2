using Delivery.Management.Application.DTOs.DeliveryRequest;
using Delivery.Management.Application.Features.DeliveryAllocations.Requests.Queries;
using Delivery.Management.Application.Features.DeliveryRequests.Requests.Command;
using Delivery.Management.Application.Features.DeliveryRequests.Requests.Queries;
using Delivery.Management.Application.Features.DeliveryTypes.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Delivery.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DeliveryRequestsController : ControllerBase
    {
        public readonly IMediator _mediator;
        public DeliveryRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<DeliveryRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<DeliveryRequestDto>>> Get()
        {
            var deliveryRequests = await _mediator.Send(new GetDeliveryRequestListRequest());
            return Ok(deliveryRequests);
        }

        // GET api/<DeliveryRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryRequestDto>> Get(int id)
        {
            var deliveryAllocation = await _mediator.Send(new GetDeliveryRequestDetailRequest());
            return Ok(deliveryAllocation);
        }

        // POST api/<DeliveryRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDeliveryRequestDto deliveryRequest)
        {
            var command = new CreateDeliveryRequestCommand { DeliveryRequestDto = deliveryRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<DeliveryRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateDeliveryRequestDto deliveryRequest)
        {
            var command = new UpdateDeliveryRequestCommand {Id = id, DeliveryRequestDto = deliveryRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<DeliveryRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteDeliveryTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
