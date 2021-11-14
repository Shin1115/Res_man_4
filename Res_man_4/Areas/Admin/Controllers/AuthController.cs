using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Res_man_4.Models;

namespace Res_man_4.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        quanlynhahangEntities db = new quanlynhahangEntities();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection filed, string uremail)
        {
            string user = filed["email"];
            string pass =MyString.toMD5(filed["password"]);
            string error = "";
            //xuly
            TAIKHOAN checkrow = getRow(user);
            if (checkrow != null)
            {
                //Login
                if (checkrow.matkhau.Equals(pass))
                {
                    Session["Useradmin"] = checkrow.email;
                    Session["UserID"] =checkrow.matk.ToString() ;
                    Session["Rules"] = checkrow.rules;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    error = "mật khẩu đéo được";
                }
                
            }
            else
            {
                error = "Đăng nhập đéo được";
            }
            ViewBag.StrError = "<div class='text-danger'>"+error+"</div>";
            return View();
        }
        public TAIKHOAN getRow(string useremail)
        {
            var finerow = db.TAIKHOAN.Where(x =>x.email == useremail).FirstOrDefault();
            return finerow;
        }

        public ActionResult Logout()
        {
            Session["Useradmin"] ="";
            Session["UserID"] = "";
            return Redirect("~/Admin/Login");

        }
    }
}