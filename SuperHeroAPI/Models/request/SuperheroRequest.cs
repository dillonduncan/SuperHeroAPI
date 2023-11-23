using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models.request
{
    public class SuperheroRequest
    {
        public String Nombre { get; set; }
        public int? AnioDebut { get; set; }
        public String ContraseniaHero { get; set; }
        public String PlanetaOrigenASuperHero { get; set; }
    }
}