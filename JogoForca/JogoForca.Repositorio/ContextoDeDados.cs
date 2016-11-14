using JogoForca.Dominio;
using JogoForca.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Repositorio
{
    public class ContextoDeDados : DbContext
    {

        public ContextoDeDados() : base("Forca")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Palavra> Palavra { get; set; }
        public DbSet<Dificuldade> Dificuldade { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
