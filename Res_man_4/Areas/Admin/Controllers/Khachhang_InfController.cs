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
    public class Khachhang_InfController : BaseHomeController
    {
        private quanlynhahangEntities db = new quanlynhahangEntities();

        // GET: Admin/Khachhang_Inf
        public ActionResult Index()
        {
            var kHACHHANG = db.KHACHHANG.Include(k => k.TAIKHOAN).Include(k => k.TINTUC);
            return View(kHACHHANG.ToList());
        }

        // GET: Admin/Khachhang_Inf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: Admin/Khachhang_Inf/Create
        public ActionResult Create()
        {
            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email");
            ViewBag.matin = new SelectList(db.TINTUC, "matin", "tieude");
            return View();
        }

        // POST: Admin/Khachhang_Inf/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makh,matin,matk,hoten,diachi,email,dienthoai")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANG.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email", kHACHHANG.matk);
            ViewBag.matin = new SelectList(db.TINTUC, "matin", "tieude", kHACHHANG.matin);
            return View(kHACHHANG);
        }

        // GET: Admin/Khachhang_Inf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email", kHACHHANG.matk);
            ViewBag.matin = new SelectList(db.TINTUC, "matin", "tieude", kHACHHANG.matin);
            return View(kHACHHANG);
        }

        // POST: Admin/Khachhang_Inf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makh,matin,matk,hoten,diachi,email,dienthoai")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.matk = new SelectList(db.TAIKHOAN, "matk", "email", kHACHHANG.matk);
            ViewBag.matin = new SelectList(db.TINTUC, "matin", "tieude", kHACHHANG.matin);
            return View(kHACHHANG);
        }

        // GET: Admin/Khachhang_Inf/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Admin/Khachhang_Inf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANG.Find(id);
            db.KHACHHANG.Remove(kHACHHANG);
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
