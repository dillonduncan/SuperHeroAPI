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
    [Authorize]

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
            return Ok(db.Superheroes_Superpoderes.ToList().Where(a => id == a.SuperpoderCodigo).Select(x => new SuperHeroe_PoderModel(x)).ToList());
        }

        // POST: api/SuperHeroe_SuperPoder
        public IHttpActionResult Post([FromBody] Superheroes_Superpoderes sph_sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            db.Superheroes_Superpoderes.Add(sph_sp);
            db.SaveChanges();
            return CreatedAtRoute("Defaultapi", new { id = sph_sp.SuperheroeID, id2 = sph_sp.SuperpoderCodigo }, sph_sp);
        }

        // PUT: api/SuperHeroe_SuperPoder/5
        public IHttpActionResult Put([FromBody] Superheroes_Superpoderes sph_sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(sph_sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(sph_sp);
        }

        // DELETE: api/SuperHeroe_SuperPoder/5
        public IHttpActionResult Delete(int id, int id2)
        {
            var sph_sp = db.Superheroes_Superpoderes.FirstOrDefault(x => x.SuperheroeID == id && x.SuperpoderCodigo == id2);
            db.Superheroes_Superpoderes.Remove(sph_sp);
            db.SaveChanges();
            return Ok(sph_sp);
        }

    }
}
