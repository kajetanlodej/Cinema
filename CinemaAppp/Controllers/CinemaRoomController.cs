using Antlr.Runtime.Misc;
using CinemaAppp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaAppp.Controllers
{
    public class CinemaRoomController : Controller
    {
        // GET: CinemaRoom
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CinemaRoom());
        }

        // Post
        [HttpPost]
        
        public ActionResult Create(CinemaRoom cinemar)
        {
            if (ModelState.IsValid)
            {
                using(DatabaseContext db = new DatabaseContext())
                {
                    db.CinemaRooms.Add(cinemar);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new CinemaRoom());
        }

        // Read
        [HttpGet]

        public ActionResult ViewAll()
        {
            List<CinemaRoom> rooms;
            using (DatabaseContext db = new DatabaseContext())
                rooms = db.CinemaRooms.ToList();
            return View(rooms);

        }
        [HttpGet]
        public ActionResult View(int id)
        {
            CinemaRoom room;

            using (DatabaseContext db = new DatabaseContext())
                room = db.CinemaRooms.FirstOrDefault(x => x.ID == id);

            return View(room);

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            CinemaRoom room;

            using (DatabaseContext db = new DatabaseContext())
                room = db.CinemaRooms.FirstOrDefault(x => x.ID == id);

            return View(room);
        }

        [HttpPost]

        public ActionResult Edit(CinemaRoom cr)
        {
            if (!ModelState.IsValid)
                return View(cr);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(cr).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]

        public ActionResult Delete(int?id)
        {
            CinemaRoom cr;
            using(DatabaseContext db = new DatabaseContext())
            {
                cr = db.CinemaRooms.FirstOrDefault(x => x.ID == id);
            }
            return View(cr);
        }

        [HttpPost,ActionName("Delete")]

        public ActionResult DeleteConfirm(int?id)
        {
            CinemaRoom cr;
            using(DatabaseContext db = new DatabaseContext())
            {
                cr = db.CinemaRooms.FirstOrDefault(x => x.ID == id);
                db.CinemaRooms.Remove(cr);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}