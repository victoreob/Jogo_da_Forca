using JogoForca.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio.Repositorio
{
    public interface IPalavraRepositorio
    {

        IList<Palavra> ListaDePalavrasComMenosOuIgualA12Caracteres();
        IList<Palavra> ListaDePalavrasComMaisQue12Caracteres();

    }
}
