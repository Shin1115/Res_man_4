using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Res_man_4.Controllers;
using Res_man_4.Models;

namespace Res_man_4.Areas.Admin.Controllers
{
    public class ShoppingCartController : BaseHomeController
    {
        quanlynhahangEntities db = new quanlynhahangEntities();
        private string strCart = "Cart";
        // GET: Admin/ShoppingCart
        public ActionResult Index()
        {
            var khachhang = db.KHACHHANG.Include(n => n.DATBAN);
            return View(khachhang.ToList());
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.MONAN.Find(id),1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = isExistingcheck(id);
                if (check == -1)
                {
                    lsCart.Add(new Cart(db.MONAN.Find(id), 1));
                }
                else
                    lsCart[check].Soluong++;
                Session[strCart] = lsCart;
            }
            return View("Index");
        }
        public int isExistingcheck(int? id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for(int i =0; i<lsCart.Count; i++)
            {
                if (lsCart[i].Monan.mamonan == id) return i;
            }
            return -1;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExistingcheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }

        public ActionResult Update(FormCollection frc)
        {
            string[] soluong = frc.GetValues("soluong");
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                lsCart[i].Soluong = Convert.ToInt32(soluong[i]) ;
            }
            Session[strCart] = lsCart;
            return View("Index");
        }

        public ActionResult CheckOut()
        {           
            return View("CheckOut");
        }
        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            //1:save the order into order table
                DATBAN order = new DATBAN()
                {
                    tenkh = frc["tenkh"],
                    diachikh = frc["diachikh"],
                    emailkh = frc["Emailkh"],
                    sodienthoaikh = frc["sodienthoaikh"],
                    ngaydat= DateTime.Now,
                    phuongthucdatban="Cash",
                    status="Processing",
                };
                db.DATBAN.Add(order);
                db.SaveChanges();
            //2:Save the order detail into order detail table
            foreach(Cart cart in lsCart)
            {
                CHITIETDATBAN ordermonan = new CHITIETDATBAN()
                {
                    madatban= order.madatban,
                    mamonan=cart.Monan.mamonan,
                    temonan=cart.Monan.tenmonan,
                    soluong=cart.Soluong,
                    gia=cart.Monan.giamonan
                };
                db.CHITIETDATBAN.Add(ordermonan);
                db.SaveChanges();
            }
            //3:Remove shopping cart session
            Session.Remove(strCart);
            return View("OrderSuccess");
        }
    }
}