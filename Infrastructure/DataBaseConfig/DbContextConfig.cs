using GerenciamentoProjetosAPI.Infrastructure.DataBaseConfig;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configura��o do banco de dados
builder.Services.AddDbContextConfig(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
