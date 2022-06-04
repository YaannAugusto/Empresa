using Loja.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x =>x.Cpf)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Func)
                .IsRequired()
                .HasColumnName("Function")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);



            builder.HasMany(x => x.Responsabilidades) //muitas tags
                .WithMany(x => x.Funcionarios) //muitos posts
                .UsingEntity<Dictionary<int, object>>( //table virtual
                "FuncionarioResponsabilidade",
                post => post.HasOne<Responsabilidade>() // um post
                    .WithMany() //ten muitas tags
                    .HasForeignKey("RespId") //nomeando a FK 
                    .HasConstraintName("FK_Responsabilidade_RespId")
                    .OnDelete(DeleteBehavior.Cascade),

                tag => tag.HasOne<Funcionario>() //Uma tag
                    .WithMany() //tem muitos posts
                    .HasForeignKey("FuncionarioId")
                    .HasConstraintName("FK_FuncionarioTag_FuncionarioId")
                    .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
