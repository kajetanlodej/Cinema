using CinemaAppp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAppp.Controllers
{
    public class ReservationsController : Controller
    {
        // GET: Reservation
        // GET: Reservation
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Reservation());
        }

        // Post
        [HttpPost]

        public ActionResult Create(Reservation res)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Reservations.Add(res);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Reservation());
        }

        // Read
        [HttpGet]

        public ActionResult ViewAll()
        {
            List<Reservation> res;
            using (DatabaseContext db = new DatabaseContext())
                res = db.Reservations.ToList();
            return View(res);

        }
        [HttpGet]
        public ActionResult View(int id)
        {
            Reservation res;

            using (DatabaseContext db = new DatabaseContext())
                res = db.Reservations.FirstOrDefault(x => x.ID == id);

            return View(res);

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            Reservation res;

            using (DatabaseContext db = new DatabaseContext())
                res = db.Reservations.FirstOrDefault(x => x.ID == id);

            return View(res);
        }

        [HttpPost]

        public ActionResult Edit(Reservation res)
        {
            if (!ModelState.IsValid)
                return View(res);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(res).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]

        public ActionResult Delete(int? id)
        {
            Reservation res;
            using (DatabaseContext db = new DatabaseContext())
            {
                res = db.Reservations.FirstOrDefault(x => x.ID == id);
            }
            return View(res);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirm(int? id)
        {
            Reservation res;
            using (DatabaseContext db = new DatabaseContext())
            {
                res = db.Reservations.FirstOrDefault(x => x.ID == id);
                db.Reservations.Remove(res);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}