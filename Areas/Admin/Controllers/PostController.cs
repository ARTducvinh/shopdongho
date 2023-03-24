using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopdongho.Models;

namespace shopdongho.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private ShopDongHODBContext db = new ShopDongHODBContext();

        // GET: Admin/Post
        public ActionResult Index()
        {
            var list = db.Posts.Where(m => m.Status != 0).OrderByDescending(m => m.Create_at).ToList();
            return View(db.Posts.ToList());
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(db.Topic.ToList(), "Id", "Name", 0);
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.Create_at = DateTime.Now;
                post.Update_at = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ListCat = new SelectList(db.Topic.ToList(), "Id", "Name", 0);
            return View(post);
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListCat = new SelectList(db.Topic.ToList(), "Id", "Name", 0);
            return View(post);
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PostId,Tile,ParentId,Slug,Metakey,Metadese,Img,Create_by,Create_at,Update_by,Update_at,Status")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(db.Topic.ToList(), "Id", "Name", 0);
            return View(post);
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Status(int id)
        {
            Post post = db.Posts.Find(id);
            int status = (post.Status == 1) ? 2 : 1;
            post.Status = status;
            post.Create_by = int.Parse(Session["UserAdmin"].ToString());
            post.Create_at = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }
        public ActionResult DelTrash(int id)
        {
            Post post = db.Posts.Find(id);
            post.Status = 0;
            post.Create_by = int.Parse(Session["UserAdmin"].ToString());
            post.Create_at = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Post");
        }
        public ActionResult ReTrash(int id)
        {
            Post post = db.Posts.Find(id);
            post.Status = 2;
            post.Create_by = int.Parse(Session["UserAdmin"].ToString());
            post.Update_at = DateTime.Now;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Post");
        }

       
    }
}
