using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JOBWAY;
using JOBWAY.Models;
using PagedList;

namespace JOBWAY.Controllers
{
    public class OffresController : Controller
    {
        private Model1 db = new Model1();

        // GET: Offres
        /**/
        public ActionResult Index(string searchString, string Categories)
        {
            var offres = from o in db.Offres
                           select o;
            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(Categories))
            {
                offres = offres.Where(s => (s.Titre.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.Ville.Contains(searchString)) && s.Categorie.Contains(Categories));
            }

            List<Offre> dispoonibles = new List<Offre>();
            foreach (var o in offres.ToList())
            {
                if(o.IsTaken == false)
                {
                    dispoonibles.Add(o);
                }
            }

            ViewBag.Categories = new SelectList(
    new List<SelectListItem>
    {
        new SelectListItem { Selected = false, Text = "Informatique", Value = "Informatique"},
        new SelectListItem { Selected = false, Text = "Web", Value ="Web"},
        new SelectListItem { Selected = false, Text = "Commerce", Value ="Commerce"},


    }, "Value", "Text", 1);

            return View(dispoonibles.OrderByDescending(x => x.DateTime));
        }

        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            ViewBag.Categorie = new SelectList(
   new List<SelectListItem>
   {
        new SelectListItem { Selected = false, Text = "Informatique", Value = "Informatique"},
        new SelectListItem { Selected = false, Text = "Web", Value ="Web"},
        new SelectListItem { Selected = false, Text = "Commerce", Value ="Commerce"},


   }, "Value", "Text", 1);

            return View();
        }

        // POST: Offres/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Offre offre)
        {
            ViewBag.Categorie = new SelectList(
   new List<SelectListItem>
   {
        new SelectListItem { Selected = false, Text = "Informatique", Value = "Informatique"},
        new SelectListItem { Selected = false, Text = "Web", Value ="Web"},
        new SelectListItem { Selected = false, Text = "Commerce", Value ="Commerce"},


   }, "Value", "Text", 1);
            if (ModelState.IsValid)
            {
                db.Offres.Add(offre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offre);
        }

        // GET: Offres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offre);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = db.Offres.Find(id);
            db.Offres.Remove(offre);
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
