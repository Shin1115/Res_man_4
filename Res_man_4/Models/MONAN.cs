//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Res_man_4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONAN()
        {
            this.DANHGIA = new HashSet<DANHGIA>();
            this.DATBAN = new HashSet<DATBAN>();
        }
    
        public int mamonan { get; set; }
        public Nullable<int> maloai { get; set; }
        public string tenmonan { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
        public Nullable<double> giamonan { get; set; }
        public Nullable<decimal> soluong { get; set; }
        public byte[] hinhmonan { get; set; }
        public Nullable<decimal> solanmua { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATBAN> DATBAN { get; set; }
        public virtual LOAIMONAN LOAIMONAN { get; set; }
    }
}