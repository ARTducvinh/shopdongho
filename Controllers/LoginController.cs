using shopdongho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace shopdongho.Controllers
{
    public class LoginController : Controller
    {
        private ShopDongHODBContext db = new ShopDongHODBContext();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string username, string pass)
        {
            if (ModelState.IsValid)
            {
                if (username == "vinh2kk2" && pass == "vinh2kk2")
                {
                    ViewBag.Admin = "Đến trang dành cho Admin";
                    return RedirectToAction("Admin", "TrangChu");
                }
                var data = db.Users.Where(s => s.UserName.Equals(username) && s.Pass.Equals(pass)).ToList();
                if (data.Count() > 0)
                {
                    //add session 
                    Session["Diachi"] = data.FirstOrDefault().Conten;
                    Session["Fullname"] = data.FirstOrDefault().FullName;
                    Session["Phone"] = data.FirstOrDefault().Phone;
                    Session["Id"] = data.FirstOrDefault().Id;
                    return RedirectToAction("Index", "TrangChuDangNhap");
                }
            }
            ViewBag.error = "Sai Tên Tài Khoản Hoặc Mật Khẩu";
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {

            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.UserName == user.UserName);
                if (check == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.error = "Tên Tài khoản đã tồn tại";
                    return View();
                }

            }

            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Login");
        }

    }


}