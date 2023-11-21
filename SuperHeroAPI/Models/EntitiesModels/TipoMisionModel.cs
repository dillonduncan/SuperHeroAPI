using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroAPI.Models
{
    public class TipoMisionModel
    {
        public TipoMisionModel(TipoMision tpm)
        {
            ID= tpm.ID;
            TipoMision1 = tpm.TipoMision1;
        }

        public int ID { get; set; }
        public string TipoMision1 { get; set; }
    }
}