using Loans.Application.Services;
using Loans.Infrastructure.Persistance.Services;
using Loans.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureCorsPolicy();
builder.Services.AddControllers();

var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors("DevCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
