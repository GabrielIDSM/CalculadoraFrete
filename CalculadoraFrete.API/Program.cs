using CalculadoraFrete.Application.Services;
using CalculadoraFrete.Client.Frenet.Services;
using CalculadoraFrete.Domain.Interfaces.Integrations;
using CalculadoraFrete.Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFreteService, FreteService>();
builder.Services.AddScoped<IFreteIntegrationService, FrenetIntegrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
