using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoForca.Dominio;
using System.Data.Entity;
using JogoForca.Dominio.Models;

namespace JogoForca.Repositorio
{
    public class JogadaRepositorio : IJogadaRepositorio
    {
        public void AlterarPontos(Jogada jogada)
        {
            using (var context = new ContextoDeDados())
            {
                jogada.Usuario = context.Usuario.Find(jogada.UsuarioRefId);
                context.Entry<Jogada>(jogada).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Jogada BuscarJogada(Jogada jogada)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Jogada.Include("Usuario").FirstOrDefault(j => j.UsuarioRefId == jogada.UsuarioRefId && j.Dificuldade.Equals(jogada.Dificuldade));
            }
        }

        public int ContarRegristros()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Jogada.Count();
            }
        }

        public void Criar(Jogada jogada)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<Jogada>(jogada).State = EntityState.Added;

                if (jogada.Usuario != null)
                    context.Entry<Usuario>(jogada.Usuario).State = EntityState.Unchanged;

                context.SaveChanges();
            }
        }

        public IEnumerable<Jogada> Ranking(int pagina, int tamanhoPagina, string filtro = "")
        {

            // tamanhoPagina = 1
            // Skip(1) = 5*(0) = 0
            // Skip(2) = 5*(2-1) = 5
            // Skip(3) = 5*(3-1) = 10

            using (var context = new ContextoDeDados())
            {
                if(filtro == "")
                {
                    return context.Jogada
                    .OrderBy(_ => _.Pontos)
                    .Skip(tamanhoPagina * (pagina - 1))
                    .Take(tamanhoPagina)
                    .ToArray();
                }else
                {
                    return context.Jogada
                    .OrderByDescending(_ => _.Pontos)
                    .ThenBy(_ => _.Usuario.Nome)
                    .Skip(tamanhoPagina * (pagina - 1))
                    .Take(tamanhoPagina)
                    .ToArray();
                }
                
            }
        }
    }
}
