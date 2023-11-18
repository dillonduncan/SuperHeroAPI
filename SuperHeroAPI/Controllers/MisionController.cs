using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroAPI.Controllers
{
    public class MisionController : ApiController
    {
        private SuperHeroesEntities1 db = new SuperHeroesEntities1();
        // GET: api/Mision
        public IHttpActionResult Get()
        {
            return Ok(db.Misiones.ToList().Select(x => new MisionModel(x)).ToList());
        }

        // GET: api/Mision/5
        public IHttpActionResult Get(int id) {
            return Ok(db.Misiones.ToList().Where(x => id == x.Codigo_Mision).Select(a => new MisionModel(a)).ToList());
        }

        // POST: api/Mision
        public IHttpActionResult Post([FromBody]Misiones ms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Misiones.Add(ms);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = ms.Codigo_Mision }, ms);
        }

        // PUT: api/Mision/5
        public IHttpActionResult Put(int id, [FromBody]Misiones ms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(ms).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(ms);
        }

        // DELETE: api/Mision/5
        public void Delete(int id)
        {
        }
    }
}
