using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Res_man_4.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
             if (System.Web.HttpContext.Current.Session["Useradmin"].Equals(""))
             {
                 //System.Web.HttpContext.Current.Response.Redirect("~/Admin/Login");
             }
        }
    }
}