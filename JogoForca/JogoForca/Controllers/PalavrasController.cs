using JogoForca.Dominio;
using JogoForca.Dominio.Models;
using JogoForca.Dominio.Repositorio;
using JogoForca.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace JogoForca.Controllers
{

    public class PalavrasController : ApiController
    {
        private PalavraServico palavraServico = ServicoDeDependencias.MontarPalavraServico();

        // GET api/palavras/normal
        [Route("api/palavras/normal")]
        [ResponseType(typeof(IList<Palavra>))]
        public IHttpActionResult GetPalavrasNivelNormal()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IList<Palavra> palavras = palavraServico.ListaDePalavrasRandomNivelNormal();

            if (palavras == null)
                return NotFound();

            return Ok(palavras);
        }

        // GET api/palavras/bh
        [Route("api/palavras/bh")]
        [ResponseType(typeof(IList<Palavra>))]
        public IHttpActionResult GetPalavrasNivelBH()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IList<Palavra> palavras = palavraServico.ListaDePalavrasRandomNivelBH();

            if (palavras == null)
                return NotFound();

            return Ok(palavras);
        }
    }
}
