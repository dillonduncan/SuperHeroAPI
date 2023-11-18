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
    public class SuperheroesController : ApiController
    {
        private SuperHeroesEntities1 db = new SuperHeroesEntities1();

        // GET: api/Superheroes
        public IHttpActionResult GetSuperheroes()
        {
            return Ok(db.Superheroes.ToList());
        }

        // GET: api/Superheroes/5
        [ResponseType(typeof(Superheroes))]
        public IHttpActionResult GetSuperheroes(int id)
        {
            Superheroes superheroes = db.Superheroes.Find(id);
            if (superheroes == null)
            {
                return NotFound();
            }

            return Ok(superheroes);
        }

        // PUT: api/Superheroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuperheroes(int id, Superheroes superheroes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superheroes.ID)
            {
                return BadRequest();
            }

            db.Entry(superheroes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperheroesExists(id))
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

        // POST: api/Superheroes
        [ResponseType(typeof(Superheroes))]
        public IHttpActionResult PostSuperheroes(Superheroes superheroes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Superheroes.Add(superheroes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = superheroes.ID }, superheroes);
        }

        // DELETE: api/Superheroes/5
        [ResponseType(typeof(Superheroes))]
        public IHttpActionResult DeleteSuperheroes(int id)
        {
            Superheroes superheroes = db.Superheroes.Find(id);
            if (superheroes == null)
            {
                return NotFound();
            }

            db.Superheroes.Remove(superheroes);
            db.SaveChanges();

            return Ok(superheroes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuperheroesExists(int id)
        {
            return db.Superheroes.Count(e => e.ID == id) > 0;
        }
    }
}