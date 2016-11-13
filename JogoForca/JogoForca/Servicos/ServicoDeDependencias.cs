using JogoForca.Dominio;
using JogoForca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JogoForca.Servicos
{
    public class ServicoDeDependencias
    {
        public static PalavraServico MontarPalavraRepositorio()
        {   
            PalavraServico palavraServico =
                new PalavraServico(
                    new PalavraRepositorio());

            return palavraServico;
        }

        public static UsuarioServico MontarUsuarioRepositorio()
        {
            UsuarioServico usuarioServico =
                new UsuarioServico(
                    new UsuarioRepositorio());

            return usuarioServico;
        }
    }
}