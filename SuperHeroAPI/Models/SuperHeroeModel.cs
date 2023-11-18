using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class SuperHeroeModel
    {
        public SuperHeroeModel(Superheroes sph)
        {
            ID = sph.ID;
            Nombre = sph.Nombre;
            AnioDebut = sph.AnioDebut;
            PlanetaOrigenASuperHero = sph.PlanetaOrigenASuperHero;
        }
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> AnioDebut { get; set; }
        public string PlanetaOrigenASuperHero { get; set; }
    }

}