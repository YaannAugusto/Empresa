using Loja.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loja.Data.Mappings
{
    public class ResponsabilidadeMap : IEntityTypeConfiguration<Responsabilidade>
    {
        public void Configure(EntityTypeBuilder<Responsabilidade> builder)
        {
            builder.ToTable("Responsabilidade");

            builder.HasKey(x => x.RespId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Ativo);
                
        }
    }
}
