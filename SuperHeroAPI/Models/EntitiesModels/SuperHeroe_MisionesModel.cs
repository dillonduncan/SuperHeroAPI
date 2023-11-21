using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class SuperHeroe_MisionesModel
    {
        public SuperHeroe_MisionesModel(Superheroes_Misiones sp_ms)
        {
            SuperheroeID=sp_ms.SuperheroeID;
            MisionCodigo=sp_ms.MisionCodigo;
            FechaAsignacion = sp_ms.FechaAsignacion;
        }
        public int SuperheroeID { get; set; }
        public int MisionCodigo { get; set; }
        public DateTime? FechaAsignacion { get; set; }

        public virtual Misiones Misiones { get; set; }
        public virtual Superheroes Superheroes { get; set; }
    }
}