using CalculadoraFrete.Application.Services;
using CalculadoraFrete.Client.Frenet.Services;
using CalculadoraFrete.Client.ViaCEP.Services;
using CalculadoraFrete.Domain.Interfaces.Integrations;
using CalculadoraFrete.Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<IFreteService, FreteService>();
builder.Services.AddScoped<IFreteIntegrationService, FrenetIntegrationService>();
builder.Services.AddScoped<IEnderecoIntegrationService, ViaCEPIntegrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
