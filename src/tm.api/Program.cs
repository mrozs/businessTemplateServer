using Microsoft.Extensions.Options;
using Serilog;
using tm.Api;
using tm.Application;
using tm.Core;
using tm.Infrastructure;
using tm.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddCors(o => o.AddPolicy("PolicyNG", builder => { builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    }))
    .AddControllers();

builder.UseSerilog();

var app = builder.Build();
app.UseCors("PolicyNG");
app.UseInfrastructure();


app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.UseUsersApi();

app.Run();
