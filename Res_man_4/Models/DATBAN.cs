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
    
    public partial class DATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATBAN()
        {
            this.KHACHHANG = new HashSet<KHACHHANG>();
            this.CHITIETDATBAN = new HashSet<CHITIETDATBAN>();
        }
    
        public int madatban { get; set; }
        public Nullable<int> mamonan { get; set; }
        public Nullable<int> maban { get; set; }
        public string tendatban { get; set; }
        public string phuongthucdatban { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> ngaydat { get; set; }
        public string tenkh { get; set; }
        public string sodienthoaikh { get; set; }
        public string emailkh { get; set; }
        public string diachikh { get; set; }
    
        public virtual BAN BAN { get; set; }
        public virtual MONAN MONAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACHHANG> KHACHHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDATBAN> CHITIETDATBAN { get; set; }
    }
}
