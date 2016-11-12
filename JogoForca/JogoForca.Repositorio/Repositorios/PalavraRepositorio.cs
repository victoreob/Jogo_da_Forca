using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoForca.Dominio.Models;

namespace JogoForca.Repositorio.Repositorios
{
    public class PalavraRepositorio : IPalavraRepositorio
    {

        public IList<Palavra> ListaDePalavras()
        {
            using (var context = new ContextoDeDados())
            {
                IList<Palavra> listaDePalavras;

                listaDePalavras = context.Palavra.ToArray();
                return listaDePalavras;
            }
        }

        public IList<Palavra> ListaDePalavrasCom12Caracteres()
        {
            using (var context = new ContextoDeDados())
            {
                IList<Palavra> listaDePalavrasNivelBH;

                listaDePalavrasNivelBH =
                    context.Palavra.Where(p => p.Nome.Length > 12).ToArray();

                return listaDePalavrasNivelBH;
            }
        }

    }
}
