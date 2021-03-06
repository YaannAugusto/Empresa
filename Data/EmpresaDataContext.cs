using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Data.Mappings;
using Loja.Models;
using Microsoft.EntityFrameworkCore;


namespace Loja.Data
{
    public class EmpresaDataContext : DbContext
    {

        public DbSet <Funcionario> Funcionarios { get; set; }
        public DbSet<Empres> Empresas { get; set; }
        public DbSet<Responsabilidade> Responsabilidades { get; set; }

        
        public EmpresaDataContext(DbContextOptions<EmpresaDataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        {
           // options.UseSqlServer(@"Server = DESKTOP-7JDET7L\SQLEXPRESS; Database = Loja;  User ID = sa; Password = 123456");
        }

        //criação de modelos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new ResponsabilidadeMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }


    }
}
