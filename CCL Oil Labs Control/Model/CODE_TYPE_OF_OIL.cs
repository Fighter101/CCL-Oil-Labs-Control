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
    
    public partial class CODE_TYPE_OF_OIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CODE_TYPE_OF_OIL()
        {
            this.CODE_OIL = new HashSet<CODE_OIL>();
            this.MAIN_TAB = new HashSet<MAIN_TAB>();
        }
    
        public int COD_TYPEOIL { get; set; }
        public string TYPE_OIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CODE_OIL> CODE_OIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAIN_TAB> MAIN_TAB { get; set; }
    }
}