namespace JogoForca.Repositorio.Migrations
{
    using Dominio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JogoForca.Repositorio.ContextoDeDados>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JogoForca.Repositorio.ContextoDeDados context)
        {
            context.Palavra.AddOrUpdate(
                p => p.Nome,
                new Palavra { Nome = "Banana" },
                new Palavra { Nome = "Star Wars" },
                new Palavra { Nome = "Escuro" },
                new Palavra { Nome = "Subtrair" },
                new Palavra { Nome = "Travesseiro" },
                new Palavra { Nome = "Morto" },
                new Palavra { Nome = "Bigode" },
                new Palavra { Nome = "Condenado" },
                new Palavra { Nome = "Germe" },
                new Palavra { Nome = "Cronometragem" },
                new Palavra { Nome = "Corda" },
                new Palavra { Nome = "Piscar" },
                new Palavra { Nome = "Caixa" },
                new Palavra { Nome = "Felino" },
                new Palavra { Nome = "Declamar" },
                new Palavra { Nome = "Vergonha" },
                new Palavra { Nome = "Mulher" },
                new Palavra { Nome = "Zeus" },
                new Palavra { Nome = "Naruto" },
                new Palavra { Nome = "Areia" },
                new Palavra { Nome = "Arquivo" },
                new Palavra { Nome = "Bochecha" },
                new Palavra { Nome = "King Kong" },
                new Palavra { Nome = "Espiral" },
                new Palavra { Nome = "Radiante" },
                new Palavra { Nome = "Gelo" },
                new Palavra { Nome = "Farol" },
                new Palavra { Nome = "Berinjela" },
                new Palavra { Nome = "Militar" },
                new Palavra { Nome = "Enfermeira" },
                new Palavra { Nome = "Nicotina" },
                new Palavra { Nome = "Leopardo" },
                new Palavra { Nome = "Oleoduto" },
                new Palavra { Nome = "Paralelepipedo" },
                new Palavra { Nome = "Otorrinolaringologista" },
                new Palavra { Nome = "Tartaruga" },
                new Palavra { Nome = "Pescador" },
                new Palavra { Nome = "Grade" },
                new Palavra { Nome = "Dinheiro" },
                new Palavra { Nome = "Significado" },
                new Palavra { Nome = "Tosse" },
                new Palavra { Nome = "Apache" },
                new Palavra { Nome = "Gravidez" },
                new Palavra { Nome = "Alfabeto" },
                new Palavra { Nome = "Coca Cola" },
                new Palavra { Nome = "Brinquedo" },
                new Palavra { Nome = "Macumba" },
                new Palavra { Nome = "Microondas" },
                new Palavra { Nome = "Forno" },
                new Palavra { Nome = "Azeite de Oliva" },
                new Palavra { Nome = "Fragmento" },
                new Palavra { Nome = "Geladeira" },
                new Palavra { Nome = "Minecraft" },
                new Palavra { Nome = "Assassins Creed" },
                new Palavra { Nome = "Pro Evolution Soccer" },
                new Palavra { Nome = "Anel" },
                new Palavra { Nome = "Smarthphone" },
                new Palavra { Nome = "Ultrabook" },
                new Palavra { Nome = "Migalha" },
                new Palavra { Nome = "Fotografia" },
                new Palavra { Nome = "Toalha" },
                new Palavra { Nome = "Odontologia" },
                new Palavra { Nome = "Manga" }
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
