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
    
    public partial class FURAN_OIL
    {
        public int FURAN_ID { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> OIL { get; set; }
        public Nullable<double> Fu { get; set; }
        public Nullable<double> Hy { get; set; }
        public Nullable<double> Ace { get; set; }
        public Nullable<double> Met { get; set; }
        public Nullable<double> Fur { get; set; }
        public Nullable<double> TOT_F { get; set; }
        public byte[] SSMA_TimeStamp { get; set; }
    
        public virtual MAIN_TAB MAIN_TAB { get; set; }
    }
}
