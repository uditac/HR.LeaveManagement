﻿
using HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.CreateLeaveallocation;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.Leavemanagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class LeaveAllocationsController : ControllerBase
//{
//    private readonly IMediator _mediator;

//    public LeaveAllocationsController(IMediator mediator)
//    {
//        _mediator = mediator;
//    }
//    // GET: api/<LeaveAllocationsController>
//    [HttpGet]
//    public async Task<ActionResult<List<LeaveAllocationDto>>>  Get(bool isLoggedInUser = false)
//    {
//        var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListQuery());
//        return Ok(leaveAllocations);
//    }

//    // GET api/<LeaveAllocationsController>/5
//    [HttpGet("{id}")]
//    public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
//    {
//        var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailQuery { Id = id});
//        return Ok(leaveAllocation);
//    }
//    // POST api/<LeaveAllocationsController>
//    [HttpPost]
//    [ProducesResponseType(201)]
//    [ProducesResponseType(400)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    public async Task<ActionResult> Post(CreateLeaveAllocationCommand leaveAllocationCommand)
//    {
//        var response = await _mediator.Send(leaveAllocationCommand);
//        return CreatedAtAction(nameof(Get), new { id = response });
//    }
   

//    // PUT api/<LeaveAllocationsController>/5
//    [HttpPut("{id}")]
   
//    [ProducesResponseType(StatusCodes.Status204NoContent)]
//    [ProducesResponseType(StatusCodes.Status404NotFound)]
//    [ProducesResponseType(400)]
//    [ProducesDefaultResponseType]
//    public async Task<ActionResult> Put(UpdateLeaveAllocationCommand updateLeaveAllocationCommand)
//    {
//        await _mediator.Send(updateLeaveAllocationCommand);
//        return NoContent();
//    }

//    // DELETE api/<LeaveAllocationsController>/5
//    [HttpDelete("{id}")]
//    public async Task<ActionResult> Delete(int id)
//    {
//        var command = new DeletelLeaveAllocationCommand { Id = id };

//        await _mediator.Send(command);
//        return NoContent();
//    }
//}
