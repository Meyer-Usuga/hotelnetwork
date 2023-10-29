using HotelNetwork.DAL.Entities;
using HotelNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace HotelNetwork.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class HotelsController : Controller
    {
        private readonly IHotelsServices _hotelServices;

        //Dependencia con la interfaz "IHotelsServices" 
        public HotelsController(IHotelsServices hotelsServices) 
        {
            _hotelServices = hotelsServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]

        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsAsync()
        {

            var hotels = await _hotelServices.GetHotelsAsync(); 
            if (hotels == null || !hotels.Any()) 
            {
                return NotFound(); 
            }
            return Ok(hotels); 

        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async Task<ActionResult> CreateHotelAsync(Hotel hotel)
        {
            try
            {
                var createdHotel = await _hotelServices.CreateHotelAsync(hotel); //traigo del servicio el objeto con los datos previamente llenados. 
                if (createdHotel == null)
                {
                    return NotFound(); 
                }
                return Ok(createdHotel); 
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El hotel {0} ya existe", hotel.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByIdAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No se ingresó id");
            }
            var hotel = await _hotelServices.GetHotelByIdAsync(id); //traigo el hotel.  
            if (hotel == null) //si es null quiere decir que no existe ningún hotel con esa id. 
            {
                return NotFound(); 
            }
            return Ok(hotel); 

        }

        [HttpGet, ActionName("Get")]
        [Route("GetByCity/{city}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelByCityAsync(string city)
        {
            if (city == null)
            {
                return BadRequest("No se ingresó la ciudad");
            }
            var hotel = await _hotelServices.GetHotelByCityAsync(city); 
            if (hotel == null) 
            {
                return NotFound();
            }
            return Ok(hotel);

        }

        [HttpPut, ActionName("Edit")]
        [Route("EditStars")]

        public async Task<ActionResult<Hotel>> EditHotelAsync(Hotel hotel, int newStars)
        {
            try
            {
                var editedHotel = await _hotelServices.EditHotelAsync(hotel, newStars);
                if (editedHotel == null)
                {
                    return NotFound();
                }
                return Ok(editedHotel);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El hotel {0} ya existe", hotel.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]

        public async Task<ActionResult<Hotel>> DeleteHotelAsync(Guid id)
        {
            if (id == null)
            {
                return BadRequest("No se ingresó el ID");
            }
            var deletedHotel = await _hotelServices.DeleteHotelAsync(id);

            if (deletedHotel == null)
            {
                return NotFound("No se encontró el hotel con ese ID");
            }
            return Ok(deletedHotel);
        }



    }
}
