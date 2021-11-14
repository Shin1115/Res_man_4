using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Res_man_4.Models
{
    using System.Collections.Generic;
    public partial class OrderDetail
    {
        public int Madatban { get; set; }
        public int Mamonan { get; set; }
        public Nullable<double> Gia { get; set; }
        public Nullable<int> Soluong { get; set; }
        public virtual DATBAN Order { get; set; }
        public virtual MONAN Monan { get; set; }
    }
}