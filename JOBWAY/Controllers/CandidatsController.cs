using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using JOBWAY.Models;

namespace JOBWAY.Controllers
{
    public class CandidatsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Candidats
        public ActionResult Index(string searchString)
        {
            var candidats = from o in db.Candidats
                         select o;
            if (!String.IsNullOrEmpty(searchString))
            {
                candidats = candidats.Where(s => s.Poste.Contains(searchString));
            }
            return View(candidats.ToList());
        }

        public void download(int? id)
        {
            
            Candidat candidat = db.Candidats.Find(id);
           

            Response.Redirect("~/files/"+candidat.Cv);
        }

        // GET: profile
        public ActionResult profile(int? id)
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
        public ActionResult Create(Candidat candidat)
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
