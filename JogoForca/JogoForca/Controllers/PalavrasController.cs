using JogoForca.Dominio.Repositorio;
using JogoForca.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JogoForca.Controllers
{

    public class PalavrasController : ApiController
    {
        //Gabriel: Acho que isso não precisa. \/
        //private IPalavraRepositorio palavras = ServicoDeDependencias.MontarPalavraRepositorio();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
