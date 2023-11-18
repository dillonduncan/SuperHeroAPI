using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class MisionModel
    {
        public MisionModel(Misiones mision)
        {
            Codigo_Mision = mision.Codigo_Mision;
            Descripcion = mision.Descripcion;
            TipoID = mision.TipoID;
            Estado_Mision= mision.Estado_Mision;
        }
        public int Codigo_Mision { get; set; }
        public string Descripcion { get; set; }
        public int TipoID { get; set; }
        public string Estado_Mision { get; set; }
    }
}
    