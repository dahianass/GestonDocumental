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
    
    public partial class Expedient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expedient()
        {
            this.CheckProcess = new HashSet<CheckProcess>();
            this.DocumentProcess = new HashSet<DocumentProcess>();
            this.Record = new HashSet<Record>();
        }
    
        public int IdExpendient { get; set; }
        public int IdProject { get; set; }
        public string FileExpendient { get; set; }
        public string Predial { get; set; }
        public string NameDemandant { get; set; }
        public Nullable<int> IdTypeProcess { get; set; }
        public string Settled { get; set; }
        public string Court { get; set; }
        public string Magistrate { get; set; }
        public string Resposible { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> appraise { get; set; }
        public System.DateTime DateCreate { get; set; }
        public int Advance { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckProcess> CheckProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentProcess> DocumentProcess { get; set; }
        public virtual Project Project { get; set; }
        public virtual TypeProcess TypeProcess { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Record> Record { get; set; }
    }
}
