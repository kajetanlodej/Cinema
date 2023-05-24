using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppp.Models.DbModels
{
    public class CinemaRoom
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }

        public CinemaRoom()
        {
            // Parameterless constructor
        }

        public CinemaRoom(int id, int number, int capacity)
        {
            ID = id;
            Number = number;
            Capacity = capacity;
        }
    }
}