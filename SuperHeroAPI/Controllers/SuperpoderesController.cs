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
    public class SuperpoderesController : ApiController
    {
        private SuperHeroesEntities1 db = new SuperHeroesEntities1();

        // GET: api/Superpoderes
        public IHttpActionResult GetSuperpoderes()
        {
            return Ok(db.Superpoderes.ToList());
        }

        // GET: api/Superpoderes/5
        [ResponseType(typeof(Superpoderes))]
        public IHttpActionResult GetSuperpoderes(int id)
        {
            Superpoderes superpoderes = db.Superpoderes.Find(id);
            if (superpoderes == null)
            {
                return NotFound();
            }

            return Ok(superpoderes);
        }

        // PUT: api/Superpoderes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuperpoderes(int id, Superpoderes superpoderes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superpoderes.CodigoPoder)
            {
                return BadRequest();
            }

            db.Entry(superpoderes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperpoderesExists(id))
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

        // POST: api/Superpoderes
        [ResponseType(typeof(Superpoderes))]
        public IHttpActionResult PostSuperpoderes(Superpoderes superpoderes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Superpoderes.Add(superpoderes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = superpoderes.CodigoPoder }, superpoderes);
        }

        // DELETE: api/Superpoderes/5
        [ResponseType(typeof(Superpoderes))]
        public IHttpActionResult DeleteSuperpoderes(int id)
        {
            Superpoderes superpoderes = db.Superpoderes.Find(id);
            if (superpoderes == null)
            {
                return NotFound();
            }

            db.Superpoderes.Remove(superpoderes);
            db.SaveChanges();

            return Ok(superpoderes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuperpoderesExists(int id)
        {
            return db.Superpoderes.Count(e => e.CodigoPoder == id) > 0;
        }
    }
}