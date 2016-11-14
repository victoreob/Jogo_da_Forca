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

namespace JogoForca.Controllers
{
    public class DificuldadesController : ApiController
    {

        private DificuldadeServico dificuldadeServico = ServicoDeDependencias.MontarDificuldadeServico;

        // GET: api/Dificuldades/5
        [ResponseType(typeof(Dificuldade))]
        public IHttpActionResult GetDificuldade(int id)
        {

            var dificuldade =
                dificuldadeServico.NomeDaDificuldade(id);

            if (dificuldade == null)
            {
                return NotFound();
            }

            return Ok(dificuldade);
        }


        /*
        // PUT: api/Dificuldades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDificuldade(int id, Dificuldade dificuldade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dificuldade.Id)
            {
                return BadRequest();
            }

            db.Entry(dificuldade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DificuldadeExists(id))
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

        // POST: api/Dificuldades
        [ResponseType(typeof(Dificuldade))]
        public IHttpActionResult PostDificuldade(Dificuldade dificuldade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dificuldade.Add(dificuldade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dificuldade.Id }, dificuldade);
        }

        // DELETE: api/Dificuldades/5
        [ResponseType(typeof(Dificuldade))]
        public IHttpActionResult DeleteDificuldade(int id)
        {
            Dificuldade dificuldade = db.Dificuldade.Find(id);
            if (dificuldade == null)
            {
                return NotFound();
            }

            db.Dificuldade.Remove(dificuldade);
            db.SaveChanges();

            return Ok(dificuldade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DificuldadeExists(int id)
        {
            return db.Dificuldade.Count(e => e.Id == id) > 0;
        }
        */
    }
}