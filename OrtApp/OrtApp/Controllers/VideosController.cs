using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrtApp.Models;

namespace OrtApp.Controllers
{
    public class VideosController : Controller
    {
        private VideoDB db = new VideoDB();

        // GET: Videos
        public ActionResult Index()
        {
            var videos = db.Videos
                .Include(v => v.Usuario)
                ;
            return View(videos.ToList());
        }

        // GET: Videos
        public ActionResult IndexUser(int? id)
        {
            var videos = from video in db.Videos
                         where video.UsuarioID==id
                         select video;

            return View(videos.ToList());
        }

        public ActionResult Ortube(int? id)
        {
            var videos = from video in db.Videos
                         where video.UsuarioID == id
                         select video;

            return View(videos.ToList());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "Nombre");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,ImgUrl,VideoUrl,UsuarioID")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Ortube", new { id = video.UsuarioID });
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "Nombre", video.UsuarioID);
            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "Nombre", video.UsuarioID);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,ImgUrl,VideoUrl,UsuarioID")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Ortube", new { id = video.UsuarioID });
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "Nombre", video.UsuarioID);
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Ortube");
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
