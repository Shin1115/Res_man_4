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
    
    public partial class CHITIETDATBAN
    {
        public int madatban { get; set; }
        public int mamonan { get; set; }
        public Nullable<double> gia { get; set; }
        public Nullable<int> soluong { get; set; }
        public string temonan { get; set; }
    
        public virtual DATBAN DATBAN { get; set; }
        public virtual MONAN MONAN { get; set; }
    }
}