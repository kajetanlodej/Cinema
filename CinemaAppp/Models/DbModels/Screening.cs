using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppp.Models.DbModels
{
    public class Screening
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int Room { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Screening()
        {
            Reservations = new List<Reservation>();
        }

        public Screening(int id, int movieID, int room, DateTime date, TimeSpan time)
        {
            ID = id;
            MovieID = movieID;
            Room = room;
            Date = date;
            Time = time;
            Reservations = new List<Reservation>();
        }
    }
}