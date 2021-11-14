using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Res_man_4.Models;
using PagedList.Mvc;
using PagedList;

namespace Res_man_4.Controllers
{
    public class HomeController : BaseHomeController
    {
        quanlynhahangEntities db = new quanlynhahangEntities();
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 6;
            List<MONAN> lstdatban = db.MONAN.ToList();
            var monanlst = db.MONAN.Include(m => m.LOAIMONAN).OrderByDescending(x => x.mamonan).ToList().ToPagedList(pageNumber, pageSize);
            return View(monanlst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blogs(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 4;
            List<MONAN> lstdatban = db.MONAN.ToList();
            var monanlst = db.MONAN.Include(m => m.LOAIMONAN).OrderByDescending(x => x.mamonan).ToList().ToPagedList(pageNumber, pageSize);
            return View(monanlst);
        }
    }
}