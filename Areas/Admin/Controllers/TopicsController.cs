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
    public class TopicsController : Controller
    {
        private ShopDongHODBContext db = new ShopDongHODBContext();

        // GET: Admin/Topics
        public ActionResult Index()
        {
            var list = db.Topic.Where(m => m.Status != 0).OrderByDescending(m => m.Create_at).ToList();
            return View("Index", list);
        }

        public ActionResult Trash()
        {
            var list = db.Topic.Where(m => m.Status == 0).OrderByDescending(m => m.Create_at).ToList();
            return View("Trash", list);
        }

        // GET: Admin/Topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: Admin/Topics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Topics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ParentId,Orders,Slug,Metakey,Metadese,Create_by,Create_at,Update_by,Update_at,Status")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topic.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        // GET: Admin/Topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Admin/Topics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ParentId,Orders,Slug,Metakey,Metadese,Create_by,Create_at,Update_by,Update_at,Status")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: Admin/Topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topic.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: Admin/Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topic.Find(id);
            db.Topic.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("Index", "Topic");
        }

        public ActionResult Status(int id)
        {
            Topic topic = db.Topic.Find(id);
            int status = (topic.Status == 1) ? 2 : 1;
            topic.Status = status;
            topic.Create_by = int.Parse(Session["UserAdmin"].ToString());
            topic.Create_at = DateTime.Now;
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Topic");
        }
        public ActionResult DelTrash(int id)
        {
            Topic Topic = db.Topic.Find(id);
            Topic.Status = 0;
            Topic.Update_by = 1;
            Topic.Create_at = DateTime.Now;
            db.Entry(Topic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Topic");
        }
        public ActionResult ReTrash(int id)
        {
            Topic Topic = db.Topic.Find(id);
            Topic.Status = 2;
            Topic.Update_by = 1;
            Topic.Create_at = DateTime.Now;
            db.Entry(Topic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Trash", "Topic");
        }
    }
}
