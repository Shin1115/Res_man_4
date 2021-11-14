using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Net;
using Res_man_4.Models;
namespace Res_man_4.Areas.Admin
{
    public class DatBanCpController : Controller
    {
        quanlynhahangEntities db = new quanlynhahangEntities();
        // GET: Admin/DatBanCp
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;
            List<DATBAN> lstdatban = db.DATBAN.ToList();
            var monanlst = db.DATBAN.OrderByDescending(x => x.mamonan).ToList().ToPagedList(pageNumber,pageSize);
            return View(monanlst);
        }

        // GET: Admin/DatBanCp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATBAN datban = db.DATBAN.Find(id);
            if (datban == null)
            {
                return HttpNotFound();
            }
            return View(datban);
        }

        // GET: Admin/DatBanCp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DatBanCp/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatBanCp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/DatBanCp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/DatBanCp/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATBAN dATBAN = db.DATBAN.Find(id);
            if (dATBAN == null)
            {
                return HttpNotFound();
            }
            return View(dATBAN);
        }

        // POST: Admin/DatBanCp/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            DATBAN dATBAN = db.DATBAN.Find(id);
            db.DATBAN.Remove(dATBAN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
