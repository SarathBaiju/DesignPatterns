using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;
using UnitOfWorkDemo.HealthCheck;
using UnitOfWorkDemo.Repository;
using UnitOfWorkDemo.Repository.Context;
using UnitOfWorkDemo.Repository.Contracts;
using UnitOfWorkDemo.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UnitOfWorkDbContext>(options =>
                                                options.UseSqlServer(connectionString: connString)
                                        );

builder.Services.AddHealthChecks().AddCheck<SqlServerHealthCheck>("SqlServer");
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

app.MapHealthChecks("health", new HealthCheckOptions
{
    ResponseWriter = ResponseWriter.CustomResponseWriter
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
