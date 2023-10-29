using HotelNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelNetwork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomsServices _roomsServices;

        //Dependencia con la interfaz "IRoomsServices" 
        public RoomsController(IRoomsServices roomsServices)
        {
            _roomsServices = roomsServices;
        }
    }
}
