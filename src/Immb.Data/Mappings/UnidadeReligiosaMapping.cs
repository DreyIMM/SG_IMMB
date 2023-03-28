using Immb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Immb.Data.Mappings
{
    public class UnidadeReligiosaMapping : IEntityTypeConfiguration<UnidadeReligiosa>
    {
        public void Configure(EntityTypeBuilder<UnidadeReligiosa> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.TipoUnidade)
               .IsRequired();

            // 1:N => U-Religiosa : Membro
            builder.HasMany(u => u.Membros)
                .WithOne(m => m.UnidadeReligiosa)
                .HasForeignKey(m => m.UnidadeReligiosaId);

            builder.ToTable("Unidades");

        }
    }
}
