using GerenciamentoProjetosAPI.Infrastructure.DataBaseConfig;
using GerenciamentoProjetosAPI.Domain.Repositories;
using GerenciamentoProjetosAPI.Infrastructure.ImplementRepositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContextConfig(builder.Configuration);

// Registrar o repositório
builder.Services.AddTransient<IProjetoRepository, ProjetoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
