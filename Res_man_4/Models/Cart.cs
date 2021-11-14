using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Res_man_4.Models
{
    public class Cart
    {
        public MONAN Monan { get; set; }
        public int Soluong { get; set; }

        public Cart(MONAN monan, int soluong)
        {
            Monan = monan;
            Soluong = soluong;
        }
    }
}