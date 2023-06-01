using Immb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Immb.Data.Mappings
{
    public class ReligiosidadeMapping : IEntityTypeConfiguration<Religiosidade>
    {
        public void Configure(EntityTypeBuilder<Religiosidade> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(r => r.Membro)
              .WithMany(m => m.Religiosidade);

            builder.Property(p => p.TotalMinistracao)
               .IsRequired();       
           


            builder.ToTable("Religiosidades");

        }
    }
}
