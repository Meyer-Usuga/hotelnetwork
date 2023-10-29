using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelNetwork.DAL.Entities
{
    public class Room : AuditBase
    {
        [Display(Name = "Número")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} sólo debe contener números.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Number { get; set; }

        [Display(Name = "Máximo de hospedados")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} sólo debe contener números.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int MaxGuests { get; set; }

        [Display(Name = "Disponibilidad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Availability { get; set; }

        [Display(Name = "IdHotel")]
        public Guid hotelId { get; set; }
    }
}
