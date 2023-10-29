using HotelNetwork.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HotelNetwork.DAL
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasIndex(c => c.Phone).IsUnique(); //el teléfono debe ser único. 
            modelBuilder.Entity<Room>().HasIndex("Number", "hotelId").IsUnique(); //Las habitaciones de un mismo Hotel deben ser únicas. 

            //.. se pueden ir añadiendo más index para todas las tablas aquí. 
        }

        #region dbsets
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        #endregion


    }
}
