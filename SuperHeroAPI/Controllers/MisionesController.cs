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
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    public class MisionesController : ApiController
    {
        private SuperHeroesEntities1 db = new SuperHeroesEntities1();

        // GET: api/Misiones
        public IHttpActionResult GetMisiones()
        {
            return Ok(db.Misiones.ToList());
        }

        // GET: api/Misiones/5
        [ResponseType(typeof(Misiones))]
        public IHttpActionResult GetMisiones(int id)
        {
            Misiones misiones = db.Misiones.Find(id);
            if (misiones == null)
            {
                return NotFound();
            }

            return Ok(misiones);
        }

        // PUT: api/Misiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMisiones(int id, Misiones misiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != misiones.Codigo_Mision)
            {
                return BadRequest();
            }

            db.Entry(misiones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MisionesExists(id))
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

        // POST: api/Misiones
        [ResponseType(typeof(Misiones))]
        public IHttpActionResult PostMisiones(Misiones misiones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Misiones.Add(misiones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = misiones.Codigo_Mision }, misiones);
        }

        // DELETE: api/Misiones/5
        [ResponseType(typeof(Misiones))]
        public IHttpActionResult DeleteMisiones(int id)
        {
            Misiones misiones = db.Misiones.Find(id);
            if (misiones == null)
            {
                return NotFound();
            }

            db.Misiones.Remove(misiones);
            db.SaveChanges();

            return Ok(misiones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MisionesExists(int id)
        {
            return db.Misiones.Count(e => e.Codigo_Mision == id) > 0;
        }
    }
}