using GerenciamentoProjetosAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoProjetosAPI.Domain.Repositories
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> GetAllAsync();
        Task<Projeto> GetByIdAsync(int id);
        Task AddAsync(Projeto projeto);
        Task UpdateAsync(Projeto projeto);
        Task DeleteAsync(int id);
    }
}
