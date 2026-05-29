using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using LuyenTapTX2_3.Models;
using Microsoft.Win32.SafeHandles;

namespace LuyenTapTX2_3.Controllers
{
    public class ProductsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Products
        public ActionResult Category()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Index(string searchString)
        {
            var product = db.Products.Select(p => p);
            if ( !String.IsNullOrEmpty(searchString))
            {
                String x = Request.Form["searchtype"];
                //product = db.Products.Where(p => p.ProdName.Contains(searchString));

                int searchInt = int.Parse(searchString);
                product = db.Products.Where(p => p.Price >= searchInt);
            }
            //ViewBag.ds2 = db.Products.OrderByDescending(p => p.Pid).Take(10).ToList();
            ViewBag.ds3 = db.Products.OrderByDescending(p => p.Price).Take(10).ToList();
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pid,Categoryid,ProdName,MetaTitle,Description,ImagePath,Price")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.ImagePath = "";
                    var f = Request.Files["ImageFile"];
                    if ( f != null && f.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Images/" + fileName);
                        f.SaveAs(UploadPath);
                        product.ImagePath = fileName;
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch ( Exception ex)
            {
                ViewBag.Error = "Lôi dữ liệu" + ex.Message;
                ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "CategoriName", product.Categoryid);
                return View(product);
            };
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pid,Categoryid,ProdName,MetaTitle,Description,ImagePath,Price")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.ImagePath = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/Images/" + FileName);
                        f.SaveAs(UploadPath);
                        product.ImagePath = FileName;
                    }
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lôi dữ liệu" + ex.Message;
                ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "CategoriName", product.Categoryid);
                return View(product);
            };
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            try
            {
                db.Products.Remove(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = "Có lỗi khi xóa " + ex.Message; 
            }
            return View("Delete", product);
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
