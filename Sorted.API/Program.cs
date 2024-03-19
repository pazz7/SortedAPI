using Serilog;
using Sorted.Application;
using Sorted.Domain.Interfaces;
using Sorted.Infrastructure.Services;
using Sorted.Infrastructure.Services.Requester;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<RainfallService>();
builder.Services.AddScoped<GetRainfallReadingsByStationIdUseCase>();
builder.Services.AddScoped<IRainfallService, UKAgencyRainfallService>();

builder.Services.AddSingleton<IApiRequester, ApiRequester>();
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

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
