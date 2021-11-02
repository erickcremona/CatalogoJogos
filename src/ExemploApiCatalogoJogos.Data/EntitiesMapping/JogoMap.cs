using ExemploApiCatalogoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploApiCatalogoJogos.Data.EntitiesMapping
{
    public class JogoMap : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.ToTable("Jogo").HasKey(c => c.Id);

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(100)")
               .IsRequired();

            builder.Property(p => p.Preco)
              .IsRequired();

            builder.Property(p => p.Produtora)
               .HasColumnType("varchar(100)")
               .IsRequired();
        }
    }
}
