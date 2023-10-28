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
        public async Task<IEnumerable<Hotels>> GetHotelsAsync() 
        {                              
            var hotels = await _context.Hotels.ToListAsync(); 
            return hotels;
        }

        public async Task<Hotels> CreateHotelAsync(Hotels hotel)
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
    }
}
