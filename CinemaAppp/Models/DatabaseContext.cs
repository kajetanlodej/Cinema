using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CinemaAppp.Models.DbModels
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("BookAppConnectionString") { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaRoom> CinemaRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Screening> Screenings { get; set; }

    }
}