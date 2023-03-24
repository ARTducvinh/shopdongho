using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using shopdongho.Models;
namespace shopdongho.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Trangchu           
        private ShopDongHODBContext db = new ShopDongHODBContext();

        public ActionResult Index()
        {
            var list = db.Products.Where(m => m.Status != 0).OrderByDescending(m => m.Create_at).ToList();
            return View("Index", list);
        }
        // GET: User/Create


        public ActionResult Admin()
        {
            return View();
        }
    }
}