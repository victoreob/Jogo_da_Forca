using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JogoForca.Dominio.Repositorio;
using JogoForca.Dominio.Models;

namespace JogoForca.Repositorio.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public int ContarRegistros()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Usuario.Count();
            }
        }

        public Usuario BuscarPorNome(string nome)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Usuario.FirstOrDefault(u => u.Nome.Equals(nome));
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (var context = new ContextoDeDados())
            {
                return context.Usuario.FirstOrDefault(u => u.Id == id);
            }
        }

        public void Criar(Usuario usuario)
        {

            using (var context = new ContextoDeDados())
            {
                context.Entry<Usuario>(usuario).State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public IEnumerable<Usuario> Ranking(int pagina, int tamanhoPagina)
        {

            // tamanhoPagina = 1
            // Skip(1) = 5*(0) = 0
            // Skip(2) = 5*(2-1) = 5
            // Skip(3) = 5*(3-1) = 10

            using (var context = new ContextoDeDados())
            {
                return context.Usuario
                    .OrderBy(_ => _.Pontuacao)
                    .Skip(tamanhoPagina * (pagina - 1))
                    .Take(tamanhoPagina)
                    .ToArray();
            }
        }

        public void ContabilizarPontos(Usuario usuario)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<Usuario>(usuario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
