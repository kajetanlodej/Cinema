using CinemaAppp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAppp.Controllers
{

    // Tutaj trzeba wykopnac sparsowanie danych tych z dat bo nie dziala zapis do bazy danych
    public class ScreeningController : Controller
    {
        // GET: Screening
        // GET: Screening
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Screening());
        }

        // Post
        [HttpPost]

        public ActionResult Create(Screening screen)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Screenings.Add(screen);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Screening());
        }

        // Read
        [HttpGet]

        public ActionResult ViewAll()
        {
            List<Screening> screen;
            using (DatabaseContext db = new DatabaseContext())
                screen = db.Screenings.ToList();
            return View(screen);

        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Screening screen;

            using (DatabaseContext db = new DatabaseContext())
                screen = db.Screenings.FirstOrDefault(x => x.ID == id);

            return View(screen);

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            Screening screen;

            using (DatabaseContext db = new DatabaseContext())
                screen = db.Screenings.FirstOrDefault(x => x.ID == id);

            return View(screen);
        }

        [HttpPost]

        public ActionResult Edit(Screening screen)
        {
            if (!ModelState.IsValid)
                return View(screen);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(screen).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            Screening screen;
            using (DatabaseContext db = new DatabaseContext())
            {
                screen = db.Screenings.FirstOrDefault(x => x.ID == id);
            }
            return View(screen);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirm(int? id)
        {
            Screening screen;
            using (DatabaseContext db = new DatabaseContext())
            {
                screen = db.Screenings.FirstOrDefault(x => x.ID == id);
                db.Screenings.Remove(screen);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}