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
    
    public partial class CheckProcess
    {
        public int IdCheckProcess { get; set; }
        public int IdExpendient { get; set; }
        public int IdCheckType { get; set; }
        public bool Complete { get; set; }
        public int Active { get; set; }
    
        public virtual CheckType CheckType { get; set; }
        public virtual Expedient Expedient { get; set; }
    }
}
