using HR.Leavemanagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); // it would see in the entire application that if its an automapper related class, it would automatially register it
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(IGenericRepository<>), typeof(IGenericRepository<>));
        services.AddScoped<ILeaveRequestRepository<LeaveRequest>, LeaveRequestRepository>();
        services.AddScoped(typeof(ILeaveAllocationRepository<>), typeof(ILeaveAllocationRepository<>));
        services.AddScoped(typeof(ILeaveTypeRepository<>), typeof(ILeaveTypeRepository<>));
        return services;
    }
}
