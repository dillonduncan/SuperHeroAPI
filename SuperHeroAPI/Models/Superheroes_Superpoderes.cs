//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperHeroAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Superheroes_Superpoderes
    {
        public int SuperheroeID { get; set; }
        public int SuperpoderCodigo { get; set; }
        public Nullable<double> NivelPoder { get; set; }
    
        public virtual Superheroes Superheroes { get; set; }
        public virtual Superpoderes Superpoderes { get; set; }
    }
}