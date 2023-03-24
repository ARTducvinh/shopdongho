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
using System.Security.Cryptography;
namespace shopdongho.Controllers
{
    
    public class TrangChuDangNhapController : Controller
    {
        private ShopDongHODBContext db = new ShopDongHODBContext();
        // GET: TrangChuDangNhap
        public ActionResult Index()
        {
            var list = db.Products.Where(m => m.Status != 0).OrderByDescending(m => m.Create_at).ToList();
            return View("Index",list);
        }

        public ActionResult Xem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product p = db.Products.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }


        public ActionResult Mua(int? id)
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
    }
}