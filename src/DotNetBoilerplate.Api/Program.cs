using System.Text.Json.Serialization;
using DotNetBoilerplate.Application;
using DotNetBoilerplate.Core;
using DotNetBoilerplate.Infrastructure;
using DotNetBoilerplate.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddShared()
    .AddApplication()
    .AddCore()
    .AddInfrastructure(builder.Configuration)
    .AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

app.UseInfrastructure();


app.Run();