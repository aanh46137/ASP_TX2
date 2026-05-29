using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticeFruit02.Models;

namespace PracticeFruit02.Controllers
{
    public class SanPhamsController : Controller
    {
        private Loaddb db = new Loaddb();

        public ActionResult thongKe()
        {
            return View(db.HangSanXuats.ToList());
        }

        public ActionResult thongKe2()
        {
            int tongSoSP = db.SanPhams.Count(x => x.DonGia >= 18000);

            ViewBag.sum = tongSoSP;

            return View();
        }

        // GET: SanPhams
        public ActionResult Index(string searchString)
        {
            var sanPhams = db.SanPhams.AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                if(int.TryParse(searchString, out int donGia))
                {
                    sanPhams = sanPhams.Where(sp => sp.DonGia <= donGia);
                }
                else
                {
                    ModelState.AddModelError("searchString", "Sản phẩm cần tìm không được nhập kiểu nguyên");
                }
            }

            return View(sanPhams.ToList());
        }

        // GET: SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,TenSP,SoLuong,DonGia,HinhAnh,MaHang")] SanPham sanPham)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    sanPham.HinhAnh = "";
                    var f = Request.Files["ImageFile"];
                    if(f != null && f.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string upLoadPath = Server.MapPath("~/images/" + fileName);
                        f.SaveAs(upLoadPath);
                        sanPham.HinhAnh = fileName;
                    }

                    db.SanPhams.Add(sanPham);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");


            }
            catch (Exception)
            {

                ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang", sanPham.MaHang);
                return View(sanPham);
            }
        }

        // GET: SanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang", sanPham.MaHang);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,TenSP,SoLuong,DonGia,HinhAnh,MaHang")] SanPham sanPham)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/images/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.HinhAnh = FileName;
                    }

                    db.Entry(sanPham).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");


            }
            catch (Exception)
            {
                ViewBag.MaHang = new SelectList(db.HangSanXuats, "MaHang", "TenHang", sanPham.MaHang);
                return View(sanPham);
            }
        }

        // GET: SanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            try
            {
                db.SanPhams.Remove(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Có lỗi khi xoá: " + ex.Message;
            }
            return View("Delete",sanPham);
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
