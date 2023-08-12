﻿using AutoMapper;
using HR.Leavemanagement.Application.Contracts.Logging;
using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.Leavemanagement.Application.Features.Queries.GetAllLeaveTypes;
using HR.Leavemanagement.Application.MappingProfiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries;
//Important
public class GetLeaveTypeListQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly IAppLogger _mockAppLogger;
    public GetLeaveTypeListQueryHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepsoitory.GetLeaveTypeMockLeaveTypeRepository();
        
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();

        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypesQueryHandler(_mapper, _mockRepo.Object,_mockAppLogger.Object);

        var result = await handler.Handle(new GetLeaveTypesQuery(),CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(1);
    }
}
