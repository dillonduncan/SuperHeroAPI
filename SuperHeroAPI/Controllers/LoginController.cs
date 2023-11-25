using SuperHeroAPI.Models;
using SuperHeroAPI.Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperHeroAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Index([FromBody] LoginRequest login)
        {
            using (SuperHeroesEntities2 db = new SuperHeroesEntities2())
            {
                try
                {
                    SuperHeroResponse superhero = db.Superheroes.ToList()
                        .Where(x => (login.Heroname.ToLower() == x.Nombre.ToLower() && x.ContraseniaHero.ToString() == login.Password.ToString()))
                        .Select(x => new SuperHeroResponse()
                        {
                            Id = x.ID,
                            Name = x.Nombre,
                            PlanetaOrigen = x.PlanetaOrigenASuperHero
                        }).FirstOrDefault();
                    if (superhero == default(SuperHeroResponse))
                    {
                       // Content<LoginResponse>()  
                        return Content<LoginResponse>(System.Net.HttpStatusCode.Unauthorized, null);
                    }
                    return Ok(new LoginResponse()
                    {
                        Token = TokenGenerater.GenerateTokenJwt(superhero.Id.ToString()),
                        DateTime = DateTime.Now,
                        SuperHero = superhero,
                        status=true
                     
                    });
                      
                }
                catch (Exception ex) { 
                        return Content(System.Net.HttpStatusCode.BadRequest, ex);
                }
            }
        }
    }
}
