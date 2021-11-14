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
using System.IO;
using Res_man_4.Controllers;

namespace Res_man_4.Areas.Admin.Controllers
{
    
    public class OrderController : BaseHomeController
    {
        quanlynhahangEntities db = new quanlynhahangEntities();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 8;
            List<MONAN> lstdatban = db.MONAN.ToList();
            var monanlst = db.MONAN.Include(m => m.LOAIMONAN).OrderByDescending(x => x.mamonan).ToList().ToPagedList(pageNumber, pageSize);
            return View(monanlst);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            DATBAN datban = db.DATBAN.FirstOrDefault(x => x.madatban == id);
            db.DATBAN.Remove(datban);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}