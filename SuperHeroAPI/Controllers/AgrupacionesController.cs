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
    public class AgrupacionesController : ApiController
{
    private SuperHeroesEntities2 db = new SuperHeroesEntities2();
    // GET: api/Agrupaciones
    public IHttpActionResult Get()
    {
        return Ok(db.Agrupaciones.ToList().Select(x => new AgrupacionesModel(x)).ToList());
    }

    // GET: api/Agrupaciones/5
    public IHttpActionResult Get(int id)
    {
        return Ok(db.Agrupaciones.ToList().Where(a => id == a.AgrupacionesID).Select(x => new AgrupacionesModel(x)).ToList());
    }

    // POST: api/Agrupaciones
    public IHttpActionResult Post([FromBody] Agrupaciones agr)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        db.Agrupaciones.Add(agr);
        db.SaveChanges();
        return CreatedAtRoute("DefaultApi", new { id = agr.AgrupacionesID }, agr);
    }

    // PUT: api/Agrupaciones/5
    public IHttpActionResult Put(int id, [FromBody] Agrupaciones agr)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        db.Entry(agr).State = System.Data.Entity.EntityState.Modified;
        db.SaveChanges();
        return Ok(agr);
    }

    // DELETE: api/Agrupaciones/5
    public IHttpActionResult Delete(int id)
    {
        var agrupacion = db.Agrupaciones.FirstOrDefault(x => x.AgrupacionesID == id);
        db.Agrupaciones.Remove(agrupacion);
        db.SaveChanges();
        return Ok(agrupacion);
    }
}
}
