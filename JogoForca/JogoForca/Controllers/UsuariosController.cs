using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JogoForca.Dominio.Models;
using JogoForca.Repositorio;
using JogoForca.Servicos;
using JogoForca.Dominio;
using JogoForca.Repositorio.Repositorios;

namespace JogoForca.Controllers
{
    public class UsuariosController : ApiController
    {
        private UsuarioServico usuarioServico = ServicoDeDependencias.MontarUsuarioServico;

        // POST: api/usuarios/cadastrar
        //[Route("api/usuarios/cadastrar")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuarios(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuarioServico.CriarUsuario(usuario);

            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        // PUT: api//usuarios/adicionarPontos
        [HttpPut]
        [Route("api/usuarios/adicionarPontos")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PutAdicionarPontos(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuarioServico.AdicionarPontos(usuario, 1);
            usuario.Pontuacao++;

            return Ok(usuario);
        }

        // PUT: api/usuarios/resetarPontos
        [HttpPut]
        [Route("api/usuarios/resetarPontos")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PutResetarPontos(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            usuarioServico.ResetarPontos(usuario);
            usuario.Pontuacao = 0;

            return Ok(usuario);
        }

        // GET: api/usuarios/buscarPorNome
        [HttpGet]
        [Route("api/usuarios/busarPorNome")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuarioPorNome(string nome)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuario usuarioResposta = usuarioServico.BuscarUsuarioPorNome(nome);

            if (usuarioResposta == null)
                return Ok(new Usuario());

            return Ok(usuarioResposta);  
        }

        // GET: api/usuarios/buscarPorId
        [HttpGet]
        [Route("api/usuarios/busarPorId")]
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuarioPorId(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuario usuarioResposta = usuarioServico.BuscarUsuarioPorId(usuario.Id);

            if (usuarioResposta == null)
                return NotFound();

            return Ok(usuarioResposta);
        }


        //GET: api/usuarios/ranking
        [HttpGet]
        [Route("api/usuarios/buscarRanking")]
        [ResponseType(typeof(IList<Usuario>))]
        public IHttpActionResult GetRanking()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IList<Usuario> usuarios = usuarioServico.CriarRanqueamento();
            
            if (usuarios == null)
                return NotFound();

            return Ok(usuarios);
        }
    }
}