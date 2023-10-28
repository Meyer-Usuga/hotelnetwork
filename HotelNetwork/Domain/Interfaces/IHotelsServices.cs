using HotelNetwork.DAL.Entities;
using System.Diagnostics.Metrics;

namespace HotelNetwork.Domain.Interfaces
{
    public interface IHotelsServices
    {
        Task<IEnumerable<Hotels>> GetHotelsAsync(); //Para traer la lista de hoteles con habitaciones disponibles. 
        Task<Hotels> CreateHotelAsync(Hotels hotel); //Para este no recibimos nada, al contrario guardamos un país tipo Country que enviamos por parametro.                                      
        //Task<Hotels> GetHotelByIdAsync(Guid id); //Me trae un hotel por id con habitaciones disponibles.  
        //Task<Hotels> GetHotelByCityAsync(string city); //Con esta tarea traeremos un hotel por ciudad. 
        //Task<Hotels> EditHotelAsync(Hotels hotel); //Para editar necesitamos el objeto completo. 
        //Task<Hotels> DeleteHotelAsync(Guid id); //Para eliminar sólo necesitamos id. 
    }
}
