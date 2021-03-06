using Res_man_4.Controllers;
using Res_man_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Res_man_4.Areas.Admin.Controllers
{
    public class NhanvienController : BaseHomeController
    {
        // GET: Admin/Nhanvien
        quanlynhahangEntities db = new quanlynhahangEntities();
        public ActionResult Index()
        {
            List<NHANVIEN> lst = new List<NHANVIEN>();
            lst = db.NHANVIEN.ToList();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NHANVIEN nv)
        {           
            db.NHANVIEN.Add(nv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            NHANVIEN nv = db.NHANVIEN.Find(id);
            return View(nv);
        }
        [HttpPost]
        public ActionResult Edit(NHANVIEN nv)
        {
            NHANVIEN editnv = db.NHANVIEN.Find(nv.manv);
            editnv.manv = nv.manv;
            editnv.tennv = nv.tennv;
            editnv.Chucvu = nv.Chucvu;
            editnv.calam = nv.calam;
            editnv.khuvuc = nv.khuvuc;
            editnv.diachi = nv.diachi;
            editnv.sodienthoai = nv.sodienthoai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            NHANVIEN nv = db.NHANVIEN.FirstOrDefault(x => x.manv == id);
            db.NHANVIEN.Remove(nv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}