using JogoForca.Dominio.Models;
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


        // CODIGO DE RANDOM EM
        // http://pt.stackoverflow.com/questions/86152/embaralhar-n%c3%bameros-de-uma-lista

        public IList<Palavra> ListaDePalavrasRandom()
        {
            IList<Palavra> listaRandomica;
            listaRandomica = palavraRepositorio.ListaDePalavras();

            var random = new Random();

            var query =
                from i in listaRandomica
                let r = random.Next()
                orderby r
                select i;

            return query.ToArray();
        }

        public IList<Palavra> ListaDePalavrasRandomNivelBH()
        {
            IList<Palavra> listaRandomica;
            listaRandomica = palavraRepositorio.ListaDePalavrasCom12Caracteres();

            var random = new Random();

            var query =
                from i in listaRandomica
                let r = random.Next()
                orderby r
                select i;

            return query.ToArray();
        }
    }
}
