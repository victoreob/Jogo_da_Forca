using JogoForca.Dominio;
using JogoForca.Repositorio;
using JogoForca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JogoForca.Servicos
{
    public class ServicoDeDependencias
    {
        public static PalavraServico MontarPalavraServico
        {
            get
            {
                return new PalavraServico(new PalavraRepositorio());
            }               
        }

        public static UsuarioServico MontarUsuarioServico
        {
            get
            {
                return new UsuarioServico(new UsuarioRepositorio());
            }
        }

        public static JogadaServico MontarJogadaServico
        {
            get
            {
                return new JogadaServico(new JogadaRepositorio());
            }
        }
    }
}