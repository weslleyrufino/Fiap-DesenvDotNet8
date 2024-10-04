using Fiap_Aula3_CadastroAlunosAPI.Implementations;
using Fiap_Aula3_CadastroAlunosAPI.Interfaces;
using Fiap_Aula3_CadastroAlunosAPI.Logging;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IBancoDados, BancoDados>();
builder.Services.AddKeyedScoped<IBancoDados, BancoDados>("Forma2");
builder.Services.AddKeyedScoped<IAlunoCadastro, AlunoCadastro>("AlunoKeyed");
builder.Services.AddScoped<IAlunoCadastro, AlunoCadastro>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// LOG
builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information,
}));
//LOG

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
