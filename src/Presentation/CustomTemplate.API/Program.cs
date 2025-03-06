using CustomTemplate.API.Configuration;
using CustomTemplate.API.Endpoints;
using Serilog;


var builder = WebApplication.CreateBuilder(args)
.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewares();
app.AddEndpoints();
app.UseHttpsRedirection();