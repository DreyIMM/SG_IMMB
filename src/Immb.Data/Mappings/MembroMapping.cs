﻿using Immb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Immb.Data.Mappings
{
    public class MembroMapping : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Telefone)
               .IsRequired();

            builder.Property(p => p.Email)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.DataOutorga);

            // 1 : 1 => Membro : Endereco
            builder.HasOne(m => m.Endereco)
                .WithOne(e => e.Membro);


            builder.ToTable("Membros");

        }
    }
}
