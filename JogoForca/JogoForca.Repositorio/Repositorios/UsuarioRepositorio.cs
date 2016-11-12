using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoForca.Dominio.Models;
using System.Data.Entity;

namespace JogoForca.Repositorio.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void AdicionarPontos(Usuario usuario, int pontos)
        {
            using (var context = new ContextoDeDados())
            {
                usuario.Pontuacao = pontos;
                context.Entry<Usuario>(usuario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<Usuario> BuscarPorNome(string nome)
        {
            using (var context = new ContextoDeDados())
            {
                IList<Usuario> listaDeUsuario;

                if (nome != null)
                {
                    listaDeUsuario = context.Usuario.Where(u => u.Nome.Contains(nome)).ToList();
                    return listaDeUsuario;
                }

                listaDeUsuario = context.Usuario.ToList();
                return listaDeUsuario;
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
                usuariosOrdenados = context.Usuario.OrderBy(u => u.Pontuacao).ToList();
                return usuariosOrdenados;
            }
        }

        public void ResetarPontos(Usuario usuario)
        {
            using (var context = new ContextoDeDados())
            {
                usuario.Pontuacao = 0; 
                context.Entry<Usuario>(usuario).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
