using GerenciamentoProjetosAPI.Domain.Entities;
using GerenciamentoProjetosAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoProjetosAPI.Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProjetosController : ControllerBase
	{
		private readonly IProjetoRepository _projetoRepository;

		public ProjetosController(IProjetoRepository projetoRepository)
		{
			_projetoRepository = projetoRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Projeto>>> GetAll()
		{
			var projetos = await _projetoRepository.GetAllAsync();
			return Ok(projetos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Projeto>> GetById(int id)
		{
			var projeto = await _projetoRepository.GetByIdAsync(id);
			if (projeto == null)
				return NotFound();
			return Ok(projeto);
		}

		[HttpPost]
		public async Task<ActionResult> Add([FromBody] Projeto projeto)
		{
			await _projetoRepository.AddAsync(projeto);
			return CreatedAtAction(nameof(GetById), new { id = projeto.Id }, projeto);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update(int id, [FromBody] Projeto projeto)
		{
			var existingProjeto = await _projetoRepository.GetByIdAsync(id);
			if (existingProjeto == null)
				return NotFound();

			projeto.Id = id;
			await _projetoRepository.UpdateAsync(projeto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var existingProjeto = await _projetoRepository.GetByIdAsync(id);
			if (existingProjeto == null)
				return NotFound();

			await _projetoRepository.DeleteAsync(id);
			return NoContent();
		}
	}
}
