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
using ApiExamenesFinal2.Models;

namespace ApiExamenesFinal2.Controllers
{
    public class ExamenesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Examenes
        public IQueryable<Examenes> GetExamenes()
        {
            return db.Examenes;
        }

        // GET: api/Examenes/5
        [ResponseType(typeof(Examenes))]
        public IHttpActionResult GetExamenes(int id)
        {
            Examenes examenes = db.Examenes.Find(id);
            if (examenes == null)
            {
                return NotFound();
            }

            return Ok(examenes);
        }

        // PUT: api/Examenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExamenes(int id, Examenes examenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examenes.id)
            {
                return BadRequest();
            }

            db.Entry(examenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenesExists(id))
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

        // POST: api/Examenes
        [ResponseType(typeof(Examenes))]
        public IHttpActionResult PostExamenes(Examenes examenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Examenes.Add(examenes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = examenes.id }, examenes);
        }

        // DELETE: api/Examenes/5
        [ResponseType(typeof(Examenes))]
        public IHttpActionResult DeleteExamenes(int id)
        {
            Examenes examenes = db.Examenes.Find(id);
            if (examenes == null)
            {
                return NotFound();
            }

            db.Examenes.Remove(examenes);
            db.SaveChanges();

            return Ok(examenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamenesExists(int id)
        {
            return db.Examenes.Count(e => e.id == id) > 0;
        }
    }
}