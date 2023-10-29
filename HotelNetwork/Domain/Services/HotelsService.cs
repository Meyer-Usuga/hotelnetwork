using HotelNetwork.DAL;
using HotelNetwork.DAL.Entities;
using HotelNetwork.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HotelNetwork.Domain.Services
{
    public class HotelsService: IHotelsServices 
    {
        public readonly DatabaseContext _context; 
        public HotelsService(DatabaseContext context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<Hotel>> GetHotelsAsync() 
        {                              
            var hotels = await _context.Hotels.Include(h => h.Rooms.Where(r => r.Availability == true)).ToListAsync(); //Solo me traerá aquellas habitaciones dónde su disponibilidad sea = "true"
            return hotels;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            try
            {
                hotel.Id = Guid.NewGuid(); 
                hotel.CreateDate = DateTime.Now;
                hotel.ModifiedDate = null;
                _context.Hotels.Add(hotel); 
                await _context.SaveChangesAsync(); 

                return hotel;
            }
            catch (DbUpdateException dbUpdateException) 
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
            
        }

        public async Task<Hotel> GetHotelByIdAsync(Guid id) //este método recibe un objeto, no una lista. 
        {
            var hotel = await _context.Hotels.Include(h => h.Rooms.Where(r => r.Availability == true)).FirstOrDefaultAsync(h => h.Id == id); //Traigo el primer hotel o sino me trae un vacio, pero no un null. 
            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetHotelByCityAsync(string city) //Me traerá todos los hoteles de "city" dada por parametro. 
        {
            var hotelsByCity = await _context.Hotels.Where(h => h.City == city).Include(h => h.Rooms.Where(r => r.Availability == true)).ToListAsync(); //Traigo todos los hoteles que tengan habitaciones disponibles en esa ciudad. 
            return hotelsByCity;
        }

        public async Task<Hotel> EditHotelAsync(Hotel hotel, int newStars)
        {
            try
            {
                hotel.ModifiedDate = DateTime.Now;
                hotel.Starts = newStars; //Asigno las nuevas estrellas
                _context.Hotels.Update(hotel); 
                await _context.SaveChangesAsync(); 

                return hotel;
            }
            catch (DbUpdateException dbUpdateException) 
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Hotel> DeleteHotelAsync(Guid id)
        {
            try
            {
                var hotel = await _context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == id); //boro el hotel y todas las habitaciones asociadas a él
                if (hotel == null)
                {
                    return null;
                }
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return hotel;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
