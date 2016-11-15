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
        public void AdicionarPontos(Usuario usuario)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<Usuario>(usuario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Usuario BuscarPorNomeENivel(string nome, string nivel)
        {
            using (var context = new ContextoDeDados())
            {
                var usuario = 
                    context.Usuario.FirstOrDefault(u => u.Nome.Equals(nome) && u.Dificuldade.Equals(nivel));

                return usuario;
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

        public IList<Usuario> Ranking()
        {
            using (var context = new ContextoDeDados())
            {
                IList<Usuario> usuariosOrdenados;
                usuariosOrdenados = context.Usuario.OrderBy(u => u.Pontuacao).ToArray();
                return usuariosOrdenados;
            }
        }

        public void ResetarPontos(Usuario usuario)
        {
            using (var context = new ContextoDeDados())
            {
                context.Entry<Usuario>(usuario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
