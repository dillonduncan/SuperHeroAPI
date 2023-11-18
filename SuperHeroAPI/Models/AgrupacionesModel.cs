using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class AgrupacionesModel
    {
        public AgrupacionesModel(Agrupaciones agr) {
            AgrupacionesID = agr.AgrupacionesID;
            Nombre = agr.Nombre;
            Nombre_integrantes=agr.Nombre_integrantes;
        }
        public int AgrupacionesID { get; set; }
        public string Nombre { get; set; }
        public string Nombre_integrantes { get; set; }
    }
}