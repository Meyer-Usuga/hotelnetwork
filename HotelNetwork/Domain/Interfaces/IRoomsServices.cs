using HotelNetwork.DAL.Entities;
using System.Diagnostics.Metrics;

namespace HotelNetwork.Domain.Interfaces
{
    public interface IRoomsServices
    {
        Task<Room> ValidateAvailabilityRoomAsync(Guid hotelId, int number); //consultamos por numero de habitación en la tabla "rooms".  
        Task<String> GetHotelName(Guid hotelId); //nos servirá para traer el nombre del hotel al que pertenece una habitación. 
    }
}
