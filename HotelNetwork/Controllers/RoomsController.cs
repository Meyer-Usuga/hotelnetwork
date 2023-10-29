using HotelNetwork.DAL.Entities;
using HotelNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelNetwork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomsServices _roomServices;

        //Dependencia con la interfaz "IRoomsServices" 

        public RoomsController(IRoomsServices roomsServices)
        {
            _roomServices = roomsServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByAvailability")]
        public async Task<ActionResult<IEnumerable<Room>>> ValidateAvailabilityRoomAsync(Guid hotelId,int number)
        {
            if (number == 0)
            {
                return BadRequest("No se ingresó el número de habitación");
            }
            var room = await _roomServices.ValidateAvailabilityRoomAsync(hotelId,number);
            var hotel = await _roomServices.GetHotelName(hotelId); 
            if (room == null) 
            {
                string errorMessage = $"Room {number} of the hotel {hotel} already booked"; //falta mirar como mostrar el nombre del hotel. Preguntar al profe. 

                return BadRequest(errorMessage);
            }
            return Ok(room);

        }
    }
}
