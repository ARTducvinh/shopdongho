using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopdongho.Models;
using System.IO;
namespace shopdongho.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ShopDongHODBContext db = new ShopDongHODBContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var list = db.Products.Where(m => m.Status != 0).OrderByDescending(m => m.Create_at).ToList();
            return View("Index", list);
        }

        // GET: Admin/Products/Details/5
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

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string slug = estring.Str_Slug(product.Name);
                product.Slug = slug;
                product.Create_at = DateTime.Now;
                product.Create_by = int.Parse(Session["UserAdmin"].ToString());
                product.Update_at = DateTime.Now;
                product.Update_by = int.Parse(Session["UserAdmin"].ToString());
                db.Products.Add(product);
                var Img = Request.Files["img"];
                string[] File = { ".jpg", ".png", ".gif" };
                if (File.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                {
                    string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                    product.Img = imgName;
                    string pathImg = Path.Combine(Server.MapPath("~/Public/Img/"), imgName);
                    Img.SaveAs(pathImg);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
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
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                string slug = estring.Str_Slug(product.Name);
                product.Slug = slug;
                product.Update_at = DateTime.Now;
                product.Update_by = int.Parse(Session["UserAdmin"].ToString());
                db.Products.Add(product);
                var Img = Request.Files["img"];
                string[] File = { ".jpg", ".png", ".gif" };
                if (Img.ContentLength != 0)
                {
                    if (File.Contains(Img.FileName.Substring(Img.FileName.LastIndexOf("."))))
                    {
                        string imgName = slug + Img.FileName.Substring(Img.FileName.LastIndexOf("."));
                        String Delpath = Path.Combine(Server.MapPath("~/Public/Img/"), product.Img);
                        if (System.IO.File.Exists(Delpath))
                        {
                            System.IO.File.Delete(Delpath);
                        }
                        product.Img = imgName;
                        string pathImg = Path.Combine(Server.MapPath("~/Public/Img/"), imgName);
                        Img.SaveAs(pathImg);
                    }
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(db.Categorys.ToList(), "Id", "Name", 0);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
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

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Trash", "Product");
        }

        public ActionResult Status(int id)
        {
            Product product = db.Products.Find(id);
            int status = (product.Status == 1) ? 2 : 1;
            product.Status = status;

            product.Create_by = int.Parse(Session["UserAdmin"].ToString());
            product.Create_at = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.stt = status;
            return RedirectToAction("Index", "Product");
        }
        public ActionResult DelTrash(int id)
        {
            Product product = db.Products.Find(id);
            product.Status = 0;
            product.Create_by = int.Parse(Session["UserAdmin"].ToString());
            product.Update_at = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult ReTrash(int id)
        {
            Product product = db.Products.Find(id);
            product.Status = 2;
            product.Create_by = int.Parse(Session["UserAdmin"].ToString());
            product.Update_at = DateTime.Now;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Product");
        }

        public ActionResult Trash(Product product)
        {
            var list = db.Products.Where(m => m.Status != 0).OrderByDescending(m => m.Create_at).ToList();
            return View("Trash", list);
        }

    }
}
