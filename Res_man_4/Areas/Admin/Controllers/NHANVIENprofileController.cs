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
    public class NHANVIENprofileController : BaseHomeController
    {
        private quanlynhahangEntities db = new quanlynhahangEntities();

        // GET: Admin/NHANVIENprofile
        public ActionResult Index(int? page)
        {
            //var nHANVIEN = db.NHANVIEN.Include(n => n.TAIKHOAN);
            //return View(nHANVIEN.ToList());
            var pageNumber = page ?? 1;
            var pageSize = 5;
            List<NHANVIEN> lstnv = db.NHANVIEN.ToList();
            var nvlst = db.NHANVIEN.OrderByDescending(x => x.manv).ToList().ToPagedList(pageNumber, pageSize);
            return View(nvlst);

        }

        // GET: Admin/NHANVIENprofile/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIEN.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: Admin/NHANVIENprofile/Create
        public ActionResult Create()
        {
            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email","matkhau");
            return View();
        }

        // POST: Admin/NHANVIENprofile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "manv,matk,tennv,Chucvu,calam,khuvuc,diachi,sodienthoai")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIEN.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email", "taikhoan", nHANVIEN.matk);
            return View(nHANVIEN);
        }

        // GET: Admin/NHANVIENprofile/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIEN.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email", nHANVIEN.matk);
            return View(nHANVIEN);
        }

        // POST: Admin/NHANVIENprofile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "manv,matk,tennv,Chucvu,calam,khuvuc,diachi,sodienthoai")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email", "matkhau", nHANVIEN.matk);
            return View(nHANVIEN);
        }

        // GET: Admin/NHANVIENprofile/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIEN.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: Admin/NHANVIENprofile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIEN.Find(id);
            db.NHANVIEN.Remove(nHANVIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
