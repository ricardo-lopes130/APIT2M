namespace GerenciamentoProjetosAPI.Domain.Entities
{
	public class Projeto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public bool Concluido { get; set; }
	}
}
