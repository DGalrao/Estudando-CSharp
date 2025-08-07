using Application.UseCases;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDb");
var mongoDatabaseName = builder.Configuration["MongoDb:DatabaseName"];
var kafkaBootstrapServers = builder.Configuration["Kafka:BootstrapServers"];

builder.Services.AddSingleton(new MongoDbContext(mongoConnectionString, mongoDatabaseName));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddSingleton(new KafkaProducer(kafkaBootstrapServers));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v1",
        Description = "API para gerenciar produtos"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. Please try again later."
            }.ToString());
        }
    });
});

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
