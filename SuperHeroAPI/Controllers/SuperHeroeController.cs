﻿using SuperHeroAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Razor.Generator;

namespace SuperHeroAPI.Controllers
{
    [Authorize]

    public class SuperHeroeController : ApiController
    {
        private SuperHeroesEntities2 db = new SuperHeroesEntities2();
        // GET: api/SuperHeroe
        public IHttpActionResult Get()
        {
            return Ok(db.Superheroes.ToList().Select(x => new SuperHeroeModel(x)).ToList());
        }

        // GET: api/SuperHeroe/5
        public IHttpActionResult Get(int id)
        {
            return Ok(db.Superheroes.ToList().Where(a => id == a.ID).Select(x => new SuperHeroeModel(x)).ToList());
        }

        // POST: api/SuperHeroe
        public IHttpActionResult Post([FromBody] Superheroes sph)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                db.Superheroes.Add(sph);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = sph.ID }, sph);
            }
            catch(Exception ex)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, ex.Message);
                
            }
        }

        // PUT: api/SuperHeroe/5
        public IHttpActionResult Put(int id, [FromBody] Superheroes sph)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(sph).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok(sph);
        }

        // DELETE: api/SuperHeroe/5
        public IHttpActionResult Delete(int id)
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
    }
}
