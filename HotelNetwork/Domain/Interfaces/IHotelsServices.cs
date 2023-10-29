using HotelNetwork.DAL.Entities;
using System.Diagnostics.Metrics;

namespace HotelNetwork.Domain.Interfaces
{
    public interface IHotelsServices
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync(); //Para traer la lista de hoteles con habitaciones disponibles. 
        Task<Hotel> CreateHotelAsync(Hotel hotel); //Para este no recibimos nada, al contrario guardamos un país tipo Country que enviamos por parametro.                                      
        Task<Hotel> GetHotelByIdAsync(Guid id); //Me trae un hotel por id con habitaciones disponibles.  
        Task<IEnumerable<Hotel>> GetHotelByCityAsync(string city); //Con esta tarea traeremos un hotel por ciudad. 
        Task<Hotel> EditHotelAsync(Hotel hotel, int newStars); //Para editar necesitamos el objeto completo para editar ese campo y las nuevas estrellas. 
        Task<Hotel> DeleteHotelAsync(Guid id); //Para eliminar sólo necesitamos id. 
    }
}
