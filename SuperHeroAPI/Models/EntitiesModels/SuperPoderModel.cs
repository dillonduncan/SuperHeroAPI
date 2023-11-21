using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class SuperPoderModel
    {
        public SuperPoderModel(Superpoderes sp) {
            CodigoPoder = sp.CodigoPoder;
               NombrePoder = sp.NombrePoder;
        }
        public int CodigoPoder { get; set; }
        public string NombrePoder { get; set; }
    }
}