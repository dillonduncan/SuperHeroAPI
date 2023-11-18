using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroAPI.Controllers
{
    public class SuperHeroe_SuperPoderController : ApiController
    {
        private SuperHeroesEntities1 db = new SuperHeroesEntities1();

        // GET: api/SuperHeroe_SuperPoder
        public IHttpActionResult Get()
        {
            return Ok(db.Superheroes_Superpoderes.ToList().Select(x => new SuperHeroe_PoderModel(x)).ToList());
        }

        // GET: api/SuperHeroe_SuperPoder/5
        public IHttpActionResult Get(int id)
        {
            return Ok(db.Superheroes_Superpoderes.ToList().Where(a=>id==a.SuperpoderCodigo).Select(x => new SuperHeroe_PoderModel(x)).ToList());
        }

        // POST: api/SuperHeroe_SuperPoder
        public IHttpActionResult Post([FromBody] Superheroes_Superpoderes sph_sp)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //db.Superheroes.Add(sph);
            //db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new {  }, sph);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Superheroes_Superpoderes.Add(sph_sp);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Superheroes_SuperpoderesExists(sph_sp.SuperheroeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sph_sp.SuperheroeID }, sph_sp);
        }

        // PUT: api/SuperHeroe_SuperPoder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SuperHeroe_SuperPoder/5
        public IHttpActionResult Delete(int id)
        {
            Superheroes_Superpoderes superheroes_Superpoderes = db.Superheroes_Superpoderes.Find(id);
            if (superheroes_Superpoderes == null)
            {
                return NotFound();
            }

            db.Superheroes_Superpoderes.Remove(superheroes_Superpoderes);
            db.SaveChanges();

            return Ok(superheroes_Superpoderes);
        }
        private bool Superheroes_SuperpoderesExists(int id)
        {
            return db.Superheroes_Superpoderes.Count(e => e.SuperheroeID == id) > 0;
        }
    }
}
