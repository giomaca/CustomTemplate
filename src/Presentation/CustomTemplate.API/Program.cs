using CustomTemplate.API.Configuration;
using CustomTemplate.API.Endpoints;
using CustomTemplate.Application;
using CustomTemplate.Persistence;
using Serilog;


var builder = WebApplication.CreateBuilder(args)
.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.AddCustomTemplateDbContext(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddApplication();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSettings(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddEndpoints();
app.UseHttpsRedirection();