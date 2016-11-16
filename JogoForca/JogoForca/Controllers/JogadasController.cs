using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JogoForca.Dominio;
using JogoForca.Repositorio;
using JogoForca.Servicos;
using JogoForca.Dominio.Models;

namespace JogoForca.Controllers
{
    public class JogadasController : ApiController
    {

        private JogadaServico jogadaServico = ServicoDeDependencias.MontarJogadaServico;

        // GET: api/Dificuldades
        [ResponseType(typeof(Jogada))]
        public IHttpActionResult GetJogadas(int idUsuario, string dificuldade)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var jogadaEncontrada = jogadaServico.BuscarJogada(
                new Jogada() { UsuarioRefId = idUsuario, Dificuldade = dificuldade });

            if (jogadaEncontrada == null)
                return Ok(new Jogada());

            return Ok(jogadaEncontrada);
        }

        [HttpPut]
        [Route("api/jogadas/alterarPontos")]
        [ResponseType(typeof(Jogada))]
        public IHttpActionResult PutJogadas(Jogada jogada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            jogadaServico.AlterarPontos(jogada);

            return Ok(jogada);
        }

        // POST: api/Dificuldades
        [ResponseType(typeof(Jogada))]
        public IHttpActionResult PostDificuldade(Jogada jogada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            jogadaServico.Criar(jogada);

            return CreatedAtRoute("DefaultApi", new { id = jogada.Id }, jogada);
        }

        // GET: api/Usuario
        [HttpGet]
        [Route("api/jogadas/ranking")]
        public IHttpActionResult GetRankingJogadas(int pagina = 1, int tamanhoPagina = 5, string filtro = "")
        {
            //pagina = pagina ?? 1;
            //tamanhoPagina = tamanhoPagina ?? 5;
            // simulando lentidão
            System.Threading.Thread.Sleep(1500);

            var registros = jogadaServico.CriarRanqueamento(pagina, tamanhoPagina, filtro);

            return Ok(new
            {
                pagina = pagina,
                dados = registros
            });
        }
    }
}