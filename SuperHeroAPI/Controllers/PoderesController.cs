using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroAPI.Controllers
{
    [Authorize]

    public class PoderesController : ApiController
    {
        private SuperHeroesEntities1 db =new SuperHeroesEntities1();
        // GET: api/Poderes
        public IHttpActionResult Get()
        {
            return Ok(db.Superpoderes.ToList().Select(x => new SuperPoderModel(x)).ToList());
        }

        // GET: api/Poderes/5
        public IHttpActionResult Get(int id)
        {
            return Ok(db.Superpoderes.ToList().Where(x => id == x.CodigoPoder).Select(a => new SuperPoderModel(a)).ToList());   
        }

        // POST: api/Poderes
        public IHttpActionResult Post([FromBody]Superpoderes sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Superpoderes.Add(sp);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new {id =  sp.CodigoPoder},sp);
             
        }

        // PUT: api/Poderes/5
        public IHttpActionResult Put(int id, [FromBody]Superpoderes sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(sp).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(sp);
        }

        // DELETE: api/Poderes/5
        public IHttpActionResult Delete(int id)
        {
            var poder = db.Superpoderes.FirstOrDefault(x => x.CodigoPoder == id);
            db.Superpoderes.Remove(poder);
            db.SaveChanges();
            return Ok(poder);
        }
    }
}
