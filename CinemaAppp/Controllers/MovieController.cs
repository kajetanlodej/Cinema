using CinemaAppp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAppp.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        // GET: Movie
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Movie());
        }

        // Post
        [HttpPost]

        public ActionResult Create(Movie mo)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Movies.Add(mo);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Movie());
        }

        // Read
        [HttpGet]

        public ActionResult ViewAll()
        {
            List<Movie> movies;
            using (DatabaseContext db = new DatabaseContext())
                movies = db.Movies.ToList();
            return View(movies);

        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Movie mo;

            using (DatabaseContext db = new DatabaseContext())
                mo = db.Movies.FirstOrDefault(x => x.ID == id);

            return View(mo);

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            Movie mo;

            using (DatabaseContext db = new DatabaseContext())
                mo = db.Movies.FirstOrDefault(x => x.ID == id);

            return View(mo);
        }

        [HttpPost]

        public ActionResult Edit(Movie mo)
        {
            if (!ModelState.IsValid)
                return View(mo);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(mo).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            Movie mo;
            using (DatabaseContext db = new DatabaseContext())
            {
                mo = db.Movies.FirstOrDefault(x => x.ID == id);
            }
            return View(mo);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirm(int? id)
        {
            Movie mo;
            using (DatabaseContext db = new DatabaseContext())
            {
                mo = db.Movies.FirstOrDefault(x => x.ID == id);
                db.Movies.Remove(mo);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}