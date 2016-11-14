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


        public Usuario BuscarUsuarioPorNomeENivel(string nomeUsuario, string nivel)
        {
            return usuarioRepositorio.BuscarPorNomeENivel(nomeUsuario, nivel);
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return usuarioRepositorio.BuscarPorId(id);
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
            return usuarioRepositorio.Ranking();
        }

    }
}
