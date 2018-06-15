//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionDocumental.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Directory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Directory()
        {
            this.Project = new HashSet<Project>();
            this.UserGD = new HashSet<UserGD>();
        }
    
        public int IdDirectory { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string DocumentIdentity { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string NumberTelephone { get; set; }
        public string Movil { get; set; }
        public Nullable<System.DateTime> DateCreate { get; set; }
        public bool Active { get; set; }
        public Nullable<bool> UseProject { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserGD> UserGD { get; set; }
    }
}
