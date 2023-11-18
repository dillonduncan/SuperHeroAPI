using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroAPI.Models
{
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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SuperHeroe_Mision/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/SuperHeroe_Mision/5
        public void Delete(int id)
        {
        }
    }
}
