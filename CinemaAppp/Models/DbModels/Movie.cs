using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaAppp.Models.DbModels
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Screening> Screenings { get; set; }

        public Movie()
        {
            Screenings = new List<Screening>();
        }

        public Movie(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
            Screenings = new List<Screening>();
        }
    }

}