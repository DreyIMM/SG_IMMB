using Immb.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Immb.Data.Context
{
    public class MeuDbContext : DbContext 
    {
        public MeuDbContext(DbContextOptions options): base(options) 
        {
                
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<UnidadeReligiosa> UnidadesReligiosas { get; set; }
        public DbSet<Membro> Membros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ajuda que caso alguma não seja mapeada, evite o varchar(max)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                          .SelectMany(e => e.GetProperties()
                              .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = ("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
            //como desabilitar Cascating Delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
