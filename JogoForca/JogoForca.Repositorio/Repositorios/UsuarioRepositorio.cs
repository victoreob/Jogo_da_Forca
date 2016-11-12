using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoForca.Dominio.Models;

namespace JogoForca.Repositorio.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void AdicionarPontos(Usuario usuario, int pontos)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Criar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Ranking()
        {
            throw new NotImplementedException();
        }

        public void ResetarPontos()
        {
            throw new NotImplementedException();
        }
    }
}
