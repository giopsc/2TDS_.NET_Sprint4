using Doracorde.API.Configuration;
using Doracorde.API.Extensions;
using Doracorde.API.Configuration;
using Doracorde.API.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
APIConfiguration apiConfiguration = new();
configuration.Bind(apiConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger(apiConfiguration);

builder.Services.AddContext(apiConfiguration);

builder.Services.AddServices();

builder.Services.AddUseCases();

builder.Services.AddRepositories();

builder
    .Services
    .AddHealthChecks()
    //.AddMongoDb(apiConfiguration.MongoSettings.URL, name: "MongoDB")
    .AddOracle(apiConfiguration.OracleFIAP.ConnectionString, name: "Oracle FIAP")
    .AddUrlGroup(new Uri("https://viacep.com.br/"), name: "VIA CEP");

var app = builder.Build();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health-check", new HealthCheckOptions()
    {
        Predicate = _ => true,
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });
});


app.Run();