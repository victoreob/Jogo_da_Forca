using JogoForca.Dominio.Models;
using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio
{
    public class UsuarioServico
    {

        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }


        public IList<Usuario> BuscarUsuarioPorNome(Usuario usuario)
        {
            var nome = usuario.Nome;
            IList<Usuario> listaDosUsuarios = usuarioRepositorio.BuscarPorNome(nome);

            return listaDosUsuarios;
        }

        public void CriarUsuario(Usuario usuario)
        {
            usuarioRepositorio.Criar(usuario);
        }

        public void AdicionarPontos(Usuario usuario, int pontos)
        {
            usuario.Pontuacao += pontos;

            usuarioRepositorio.AdicionarPontos(usuario);
        }


        public void ResetarPontos(Usuario usuario)
        {
            usuario.Pontuacao = 0;

            usuarioRepositorio.ResetarPontos(usuario);
        }

        public IList<Usuario> CriarRanqueamento()
        {
            IList<Usuario> listaRanqueada;
            listaRanqueada = usuarioRepositorio.Ranking();

            return listaRanqueada;
        }

    }
}
