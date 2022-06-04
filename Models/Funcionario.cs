namespace Loja.Models
{
    public class Funcionario
    { 
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Func { get; set; }

        public IList<Empres> Empresas { get; set; }

        public List<Responsabilidade> Responsabilidades { get; set; }
    }
}
