//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GD.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeProcess
    {
        public TypeProcess()
        {
            this.CheckType = new HashSet<CheckType>();
            this.Expedient = new HashSet<Expedient>();
        }
    
        public int IdTypeProcess { get; set; }
        public string Name { get; set; }
        public string Descriptionq { get; set; }
        public bool Active { get; set; }
        public bool UseType { get; set; }
    
        public virtual ICollection<CheckType> CheckType { get; set; }
        public virtual ICollection<Expedient> Expedient { get; set; }
    }
}
