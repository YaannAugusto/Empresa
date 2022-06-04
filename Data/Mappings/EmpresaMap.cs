using Loja.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empres>
    {
        public void Configure(EntityTypeBuilder<Empres> builder)
        {
            //Tabela
            builder.ToTable("Empres");

            //Chave Primária
            builder.HasKey(x => x.EmployeeId);


            //Propriedades

            builder.Property(x => x.Company)
                .IsRequired()
                .HasColumnName("Company")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);


            builder.Property(x => x.Cep)
                .IsRequired()
                .HasColumnName("CEP")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            //Relacionamento
            //um para muitos
            builder.HasOne(x => x.Funcionarios)
                .WithMany(x=>x.Empresas)
                .HasConstraintName("FK_Empresa_Funcionario")
                .OnDelete(DeleteBehavior.Cascade);
                
                    
        }
           
    }
}
