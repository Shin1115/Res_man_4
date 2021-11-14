﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Res_man_4.Controllers
{
    public class BaseHomeController : Controller
    {
        // GET: BaseHome
        public BaseHomeController()
        {
                if (System.Web.HttpContext.Current.Session["Useradmin"].Equals(""))
                {
                    System.Web.HttpContext.Current.Response.Redirect("~/Login/Login");
                }
        }
    }
}