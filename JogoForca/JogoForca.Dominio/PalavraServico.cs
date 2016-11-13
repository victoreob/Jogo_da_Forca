using JogoForca.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoForca.Dominio
{
    public class PalavraServico
    {

        private IPalavraRepositorio palavraRepositorio;

        public PalavraServico(IPalavraRepositorio palavraRepositorio)
        {
            this.palavraRepositorio = palavraRepositorio;
        }





    }
}
