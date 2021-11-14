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
    public class MonAnController : BaseHomeController
    {
        private quanlynhahangEntities db = new quanlynhahangEntities();

        // GET: Admin/MonAn
        public ActionResult Index(int? page)
        {
            //var mONAN = db.MONAN.Include(m => m.LOAIMONAN);
            var pageNumber = page ?? 1;
            var pageSize = 5;
            List<MONAN> lstdatban = db.MONAN.ToList();
            var monanlst = db.MONAN.Include(m => m.LOAIMONAN).OrderByDescending(x => x.mamonan).ToList().ToPagedList(pageNumber, pageSize);
            return View(monanlst);
        }

        // GET: Admin/MonAn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONAN.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            return View(mONAN);
        }

        // GET: Admin/MonAn/Create
        [HttpGet]
        public ActionResult Create()
        {
           //MONAN monan = new MONAN();
            //ViewBag.maloai = new SelectList(db.LOAIMONAN, "maloai", "tenloai");
            return View();

        }

        // POST: Admin/MonAn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(MONAN monan , HttpPostedFileBase uploadhinh)
        {
            db.MONAN.Add(monan);
            db.SaveChanges();
            if (uploadhinh !=null && uploadhinh.ContentLength>0)
            {
                int id = int.Parse(db.MONAN.ToList().Last().mamonan.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "ma" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Areas/Admin/UpLoad/HinhMonAn/"), _FileName);
                uploadhinh.SaveAs(_path);

                MONAN man = db.MONAN.FirstOrDefault(x => x.mamonan == id);
                man.hinhma=_FileName;
                db.SaveChanges();
            }

            //ViewBag.maloai = new SelectList(db.LOAIMONAN, "maloai", "tenloai", monan.maloai);
            return RedirectToAction("Index");
            
        }

        // GET: Admin/MonAn/Edit/5
        public ActionResult Edit(int? id)
        {
            MONAN monan = db.MONAN.FirstOrDefault(x=>x.mamonan==id);
            //ViewBag.maloai = new SelectList(db.LOAIMONAN, "maloai", "tenloai", mONAN.maloai);
            return View(monan);
        }

        // POST: Admin/MonAn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit( MONAN monan , HttpPostedFileBase uploadhinh)
        {
            MONAN editma = db.MONAN.FirstOrDefault(x=>x.mamonan==monan.mamonan);
            editma.tenmonan = monan.tenmonan;
            editma.ngaydat = monan.ngaydat;
            editma.giamonan = monan.giamonan;
            editma.soluong = monan.soluong;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = monan.mamonan;

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "ma" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Areas/Admin/UpLoad/HinhMonAn/"), _FileName);
                uploadhinh.SaveAs(_path);
                editma.hinhma = _FileName;
                
            }
            db.SaveChanges();
            return RedirectToAction("Index");
            //ViewBag.maloai = new SelectList(db.LOAIMONAN, "maloai", "tenloai", monan.maloai);
        }

        // GET: Admin/MonAn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONAN mONAN = db.MONAN.Find(id);
            if (mONAN == null)
            {
                return HttpNotFound();
            }
            return View(mONAN);
        }

        // POST: Admin/MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MONAN mONAN = db.MONAN.Find(id);
            db.MONAN.Remove(mONAN);
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
