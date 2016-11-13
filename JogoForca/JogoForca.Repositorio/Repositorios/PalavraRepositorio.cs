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

        public IList<Palavra> ListaDePalavrasComMenosOuIgualA12Caracteres()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Palavra.Where(p => p.Nome.Length <= 12).ToArray();
            }
        }

        public IList<Palavra> ListaDePalavrasComMaisQue12Caracteres()
        {
            using (var context = new ContextoDeDados())
            {
                return context.Palavra.Where(p => p.Nome.Length > 12).ToArray();
            }
        }

    }
}
