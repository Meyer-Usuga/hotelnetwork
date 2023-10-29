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
    }
}
