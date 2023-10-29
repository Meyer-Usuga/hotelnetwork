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
        private readonly IHotelsServices _hotelsServices;

        //Dependencia con la interfaz "IHotelsServices" 
        public HotelsController(IHotelsServices hotelsServices) 
        {
            _hotelsServices = hotelsServices;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]

        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsAsync()
        {

            var hotels = await _hotelsServices.GetHotelsAsync(); 
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
                var createdHotel = await _hotelsServices.CreateHotelAsync(hotel); //traigo del servicio el objeto con los datos previamente llenados. 
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




    }
}
