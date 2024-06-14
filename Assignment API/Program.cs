using AspNetCore.Identity.LiteDB.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using LiteDbContext = Assignment.Data.LiteDbContext;
using Assignment.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Assignment.Middleware;
using Assignment.Services;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Alerts and Events",
        Description = "An ASP.Net Web API Service for managing Alerts and Events ",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    options.EnableAnnotations();
});


// Inside your ConfigureServices method in Startup.cs or a similar configuration method
builder.Services.Configure<LiteDbOptions>(configuration.GetSection("LiteDbOptions"));
builder.Services.AddSingleton<ILiteDbContext, LiteDbContext>();
builder.Services.AddTransient<ILiteDbAlertModelService, LiteAlertModel>();
builder.Services.AddSingleton<ILiteDbContext,EventLiteDbContext>(); 
builder.Services.AddTransient<ILiteEventModelService, LiteEventModel>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandler>();
app.UseAuthorization();

app.MapControllers();

app.Run();
