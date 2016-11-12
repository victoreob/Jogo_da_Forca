using JogoForca.Dominio.Repositorio;
using JogoForca.Repositorio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JogoForca.Servicos
{
    public class ServicoDeDependencias
    {
        public static IPalavraRepositorio MontarPalavraRepositorio()
        {
            return new PalavraRepositorio();
        }

        public static IUsuarioRepositorio MontarUsuarioRepositorio()
        {
            return new UsuarioRepositorio();
        }
    }
}