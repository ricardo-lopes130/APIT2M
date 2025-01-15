using GerenciamentoProjetosAPI.Infrastructure.DataBaseConfig;
using GerenciamentoProjetosAPI.Domain.Repositories;
using GerenciamentoProjetosAPI.Infrastructure.ImplementRepositories;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do banco de dados
builder.Services.AddDbContextConfig(builder.Configuration);

// Registrar o reposit�rio
builder.Services.AddTransient<IProjetoRepository, ProjetoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
