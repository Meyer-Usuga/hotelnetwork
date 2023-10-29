using HotelNetwork.DAL.Entities;
using System.Diagnostics.Metrics;

namespace HotelNetwork.DAL
{
    public class SeederDB
    {
        private readonly DatabaseContext _context;

        public SeederDB(DatabaseContext context)
        {
            _context = context;
        }
        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //Esta línea me ayuda a crear mi BD de forma automática
            await PopulateHotelsAsync();

            await _context.SaveChangesAsync();
        }
        private async Task PopulateHotelsAsync()
        {
            if (!_context.Hotels.Any())
            {
                _context.Hotels.Add(new Hotel
                {
                    CreateDate = DateTime.Now,
                    Name = "Luxury Diamante",
                    Address = "Crra 83 #84-5", 
                    Phone = "8800321", 
                    Starts = 5,
                    City = "Cartagena",
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 202,
                            MaxGuests = 3,
                            Availability = true
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 321,
                            MaxGuests = 5,
                            Availability = false
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 500,
                            MaxGuests = 2,
                            Availability = true
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreateDate = DateTime.Now,
                    Name = "Sixtina plaza",
                    Address = "Calle 98b #83-44",
                    Phone = "3220059",
                    Starts = 4,
                    City = "Medellin",
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 411,
                            MaxGuests = 5,
                            Availability = false
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 125,
                            MaxGuests = 2,
                            Availability = true
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 092,
                            MaxGuests = 1,
                            Availability = false
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreateDate = DateTime.Now,
                    Name = "Donde toño",
                    Address = "Calle 65a #20-1",
                    Phone = "9856852",
                    City = "Cali",
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 15,
                            MaxGuests = 1,
                            Availability = true
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 5,
                            MaxGuests = 2,
                            Availability = false
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 8,
                            MaxGuests = 3,
                            Availability = true
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreateDate = DateTime.Now,
                    Name = "La mansión",
                    Address = "Crra 106 #99-2",
                    Phone = "1293211",
                    City = "Cali",
                    Starts = 5,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 606,
                            MaxGuests = 1,
                            Availability = true
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 707,
                            MaxGuests = 2,
                            Availability = false
                        },

                        new Room
                        {
                            CreateDate = DateTime.Now,
                            Number = 805,
                            MaxGuests = 3,
                            Availability = false
                        }
                    }
                });
            }
        }
    }
}
