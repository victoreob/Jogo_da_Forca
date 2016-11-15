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


        public Usuario BuscarUsuarioPorNome(string nomeUsuario)
        {
            return usuarioRepositorio.BuscarPorNome(nomeUsuario);
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return usuarioRepositorio.BuscarPorId(id);
        }

        public void CriarUsuario(Usuario usuario)
        {
            usuarioRepositorio.Criar(usuario);
        }
    }
}
