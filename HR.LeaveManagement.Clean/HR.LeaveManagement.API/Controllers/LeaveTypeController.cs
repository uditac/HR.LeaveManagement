using HR.Leavemanagement.Application.Features.Commands.CreateLeaveType;
using HR.Leavemanagement.Application.Features.Commands.DeleteLeaveType;
using HR.Leavemanagement.Application.Features.Commands.UpdateleaveType;
using HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;
using HR.Leavemanagement.Application.Features.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveTypeController(IMediator mediator)
    {
        _mediator = mediator;
        
    }
    // GET: api/<LeaveTypeController>
    [HttpGet]
    public async Task<List<LeaveTypeDto>> Get()
    {
       var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
        return leaveTypes;  
    }

    // GET api/<LeaveTypeController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDetailsDto>> Get(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
        return leaveType;
    }

    // POST api/<LeaveTypeController>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType)
    {
        var response = await _mediator.Send(leaveType);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT api/<LeaveTypeController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(UpdateLeaveTypeCommand updateLeaveType) 
    {
        var response = await _mediator.Send(updateLeaveType);
        return NoContent();
    }

    // DELETE api/<LeaveTypeController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLeaveTypeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
