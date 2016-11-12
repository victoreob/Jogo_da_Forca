using JogoForca.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> Ranking();
        IList<Usuario> BuscarPorNome(string nome);
        void Criar(Usuario usuario);
        void AdicionarPontos(Usuario usuario, int pontos);
        void ResetarPontos(Usuario usuario);
    }
}
