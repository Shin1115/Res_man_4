using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Res_man_4.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //if (Session["Useradmin"].Equals(""))
            //{
            //    return Redirect("~/Admin/Login");
            //}
            return View();
        }
    }
}