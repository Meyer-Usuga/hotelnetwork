using HotelNetwork.DAL;
using HotelNetwork.DAL.Entities;
using HotelNetwork.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelNetwork.Domain.Services
{
    public class RoomsService : IRoomsServices
    {
        //Inyectamos dependencia con la base de datos para poder usar funciones del crud. 
        public readonly DatabaseContext _context;
        public RoomsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Room> ValidateAvailabilityRoomAsync(Guid hotelId, int number) 
        {
            var room = await _context.Rooms.Where(r => r.Availability == true).FirstOrDefaultAsync(r => r.Number == number && r.hotelId == hotelId);
            if(room == null)
            {
                return null;
            }
            else
            return room;
        }

        public async Task<String>GetHotelName(Guid hotelId)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == hotelId);
            return hotel.Name; 
        }
    }
}
