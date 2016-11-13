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

namespace JogoForca.Controllers
{
    public class UsuariosController : ApiController
    {
        private ContextoDeDados db = new ContextoDeDados();

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ServicoDeDependencias.MontarUsuarioRepositorio().CriarUsuario(usuario);

            //await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }


        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostPontosUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ServicoDeDependencias.MontarUsuarioRepositorio().AdicionarPontos(usuario, 1);

            //await db.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }

        // GET: api/Usuario/5/Resetar
        public void ResetarPontos(Usuario usuario)
        {
            ServicoDeDependencias.MontarUsuarioRepositorio().ResetarPontos(usuario);
        }

        // GET: api/Usuarios
        public IList<Usuario> GetListUsuario(Usuario usuario)
        {
            return ServicoDeDependencias.MontarUsuarioRepositorio().BuscarUsuarioPorNome(usuario);            
            
        }


        //GET: api/Usuarios/Ranking
        public IList<Usuario> GetRanking()
        {
            return ServicoDeDependencias.MontarUsuarioRepositorio().CriarRanqueamento();
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id)
            {
                return BadRequest();
            }


            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.Id == id) > 0;
        }
    }
}