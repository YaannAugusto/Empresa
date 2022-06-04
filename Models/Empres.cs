using System;

namespace Loja.Models
{
    public class Empres
    {
       
        public string Cep { get; set; }
        public string Company { get; set; }
        public int EmployeeId { get; set; }
        
        public Funcionario? Funcionarios { get; set; }

    }
}
