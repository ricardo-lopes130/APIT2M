using Dapper;
using GerenciamentoProjetosAPI.Domain.Entities;
using GerenciamentoProjetosAPI.Domain.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GerenciamentoProjetosAPI.Infrastructure.ImplementRepositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProjetoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Projeto>> GetAllAsync()
        {
            var sql = "SELECT * FROM Projetos";
            return await _dbConnection.QueryAsync<Projeto>(sql);
        }

        public async Task<Projeto> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Projetos WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Projeto>(sql, new { Id = id });
        }

        public async Task AddAsync(Projeto projeto)
        {
            var sql = "INSERT INTO Projetos (Nome, Descricao, Concluido) VALUES (@Nome, @Descricao, @Concluido)";
            await _dbConnection.ExecuteAsync(sql, projeto);
        }

        public async Task UpdateAsync(Projeto projeto)
        {
            var sql = "UPDATE Projetos SET Nome = @Nome, Descricao = @Descricao, Concluido = @Concluido WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, projeto);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Projetos WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
