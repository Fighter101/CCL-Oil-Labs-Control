//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CCL_Oil_Labs_Control.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRANSFORMER_OIL
    {
        public int TRANSFORMER_ID { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> OIL { get; set; }
        public Nullable<double> SG { get; set; }
        public Nullable<double> COL { get; set; }
        public Nullable<double> IMP { get; set; }
        public Nullable<double> WA { get; set; }
        public Nullable<double> IPI { get; set; }
        public Nullable<double> KV { get; set; }
        public Nullable<double> PF { get; set; }
        public Nullable<double> ST { get; set; }
        public Nullable<double> KI { get; set; }
        public Nullable<double> FL { get; set; }
        public Nullable<double> CO { get; set; }
        public string KF { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    
        public virtual MAIN_TAB MAIN_TAB { get; set; }
    }
}
