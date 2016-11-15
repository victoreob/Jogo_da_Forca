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
    }
}
