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
    
    public partial class Superheroes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Superheroes()
        {
            this.Superheroes_Misiones = new HashSet<Superheroes_Misiones>();
            this.Agrupaciones = new HashSet<Agrupaciones>();
            this.Superheroes_Superpoderes = new HashSet<Superheroes_Superpoderes>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> AnioDebut { get; set; }
        public string PlanetaOrigenASuperHero { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Superheroes_Misiones> Superheroes_Misiones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agrupaciones> Agrupaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Superheroes_Superpoderes> Superheroes_Superpoderes { get; set; }
    }
}
