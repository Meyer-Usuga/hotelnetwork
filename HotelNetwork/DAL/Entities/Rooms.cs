using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelNetwork.DAL.Entities
{
    public class Rooms : AuditBase
    {
        [Display(Name = "Habitaciión")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo 50 caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String Name { get; set; }

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
