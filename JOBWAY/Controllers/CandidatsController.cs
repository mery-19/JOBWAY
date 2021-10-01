using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JOBWAY;
using JOBWAY.Models;

namespace JOBWAY.Controllers
{
    public class CandidatsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Candidats
        public ActionResult Index()
        {
            return View(db.Candidats.ToList());
        }

        public void download()
        {
            //PdfFiles is the name of the folder where these pdf files are located
            /*  var path = Server.MapPath("~/files/cv.pdf");
              var memory = new MemoryStream();
              using (var stream = new FileStream(path, FileMode.Open))
              {
                  stream.CopyToAsync(memory);
              }
              memory.Position = 0;
              return File(memory, "application/pdf", Path.GetFileName(path));*/

            Response.Redirect("~/files/cv.pdf");
        }

        // GET: profile
        public ActionResult profile()
        {
            return View();
        }

        // GET: Candidats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidat candidat = db.Candidats.Find(id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        // GET: Candidats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usernname,Password,Description,Cv,Phone,Email,Date_creation")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                db.Candidats.Add(candidat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidat);
        }

        // GET: Candidats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidat candidat = db.Candidats.Find(id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        // POST: Candidats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usernname,Password,Description,Cv,Phone,Email,Date_creation")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidat);
        }

        // GET: Candidats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidat candidat = db.Candidats.Find(id);
            if (candidat == null)
            {
                return HttpNotFound();
            }
            return View(candidat);
        }

        // POST: Candidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidat candidat = db.Candidats.Find(id);
            db.Candidats.Remove(candidat);
            db.SaveChanges();
            return RedirectToAction("Index");
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
