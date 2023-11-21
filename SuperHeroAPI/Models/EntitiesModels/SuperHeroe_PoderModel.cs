using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class SuperHeroe_PoderModel
    {
        public SuperHeroe_PoderModel(Superheroes_Superpoderes sph_sp) {
            SuperheroeID = sph_sp.SuperheroeID;
            SuperpoderCodigo= sph_sp.SuperpoderCodigo;
            NivelPoder=sph_sp.NivelPoder;

        }
        public int SuperheroeID { get; set; }
        public int SuperpoderCodigo { get; set; }
        public double? NivelPoder { get; set; }

        public virtual Superheroes Superheroes { get; set; }
        public virtual Superpoderes Superpoderes { get; set; }
    }
}