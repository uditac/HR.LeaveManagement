using HR.Leavemanagement.Application;
using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Infrastructure;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
//builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddControllers();

//API can be called by anaybody
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
    .AllowAnyHeader().
    AllowAnyMethod());
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
   // options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //if you dont use Jwt i think you can just delete this line
}).AddCookie(/*cookie=> you can add some options here*/);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("all");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<HRDatabaseContext>();
    db.Database.Migrate();
}

app.Run();
