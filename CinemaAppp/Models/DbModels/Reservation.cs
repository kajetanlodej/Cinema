using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppp.Models.DbModels
{
    public class Reservation
    {
        public int ID { get; set; }
        public int ScreeningID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SeatNumber { get; set; }

        public Reservation()
        {
            // Parameterless constructor
        }

        public Reservation(int id, int screeningID, string firstName, string lastName, int seatNumber)
        {
            ID = id;
            ScreeningID = screeningID;
            FirstName = firstName;
            LastName = lastName;
            SeatNumber = seatNumber;
        }
    }
}