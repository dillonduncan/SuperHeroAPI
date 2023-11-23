using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroAPI.Models
{
    [Authorize]

    public class SuperHeroe_MisionController : ApiController
    {
        private SuperHeroesEntities1 db = new SuperHeroesEntities1();

        // GET: api/SuperHeroe_Mision
        public IHttpActionResult Get()
        {
            return Ok(db.Superheroes_Misiones.ToList().Select(x => new SuperHeroe_MisionesModel(x)).ToList());
        }

        // GET: api/SuperHeroe_Mision/5
        public IHttpActionResult Get(int id)
        {
            return Ok(db.Superheroes_Misiones.ToList().Where(a => id == a.MisionCodigo).Select(x => new SuperHeroe_MisionesModel(x)).ToList());
        }

        // POST: api/SuperHeroe_Mision
        public IHttpActionResult Post([FromBody]Superheroes_Misiones sh_ms )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            db.Superheroes_Misiones.Add(sh_ms);
            db.SaveChanges();
            return CreatedAtRoute("Defaultapi", new { id = sh_ms.SuperheroeID, id2 = sh_ms.MisionCodigo }, sh_ms);
        }

        // PUT: api/SuperHeroe_Mision/5
        public IHttpActionResult Put([FromBody] Superheroes_Misiones sh_ms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(sh_ms).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(sh_ms);
        }

        // DELETE: api/SuperHeroe_Mision/5
        public IHttpActionResult Delete(int id,int id2)
        {
            var sh_ms = db.Superheroes_Misiones.FirstOrDefault(x => x.SuperheroeID == id && x.MisionCodigo == id2);
            db.Superheroes_Misiones.Remove(sh_ms);
            db.SaveChanges();
            return Ok(sh_ms);
        }
    }
}
