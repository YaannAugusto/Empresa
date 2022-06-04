namespace Loja.Models
{
    public class Responsabilidade
    {
        public int RespId { get; set; }
        public string Name { get; set; }
        public bool Ativo { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
