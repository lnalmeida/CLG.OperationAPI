using MediatR;
using CLG.OperationsAPI.Application.Entity;
using CLG.OperationsAPI.Application.Repository;
using CLG.OperationsAPI.Application.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/* DB configs */
// var dbHost = "172.17.0.3";
// var dbName = "db_movements";
// var dbPassword = "root";

// var connectionString = "server=172.17.0.3; port=3306; database=db_movements; user=root; password=root";
builder.Services.AddDbContext<OperationContext>(o => o.UseSqlite("Data Source=db_movements.db"));
/*==========================================================================*/

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IRepository<Operation>, OperationRepository>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
