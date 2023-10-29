using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelNetwork.DAL.Entities
{
    public class Hotel: AuditBase
    {
        [Display(Name = "Hotel")] 
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo 50 caracteres.")] 
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String Name { get; set; } 

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo 100 caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String Address { get; set; } 

        [Display(Name = "Teléfono")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} sólo debe contener números.")]       
        public String? Phone { get; set; } 

        [Display(Name = "Estrellas")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} sólo debe contener números.")]
        public int? Starts { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo 50 caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public String City { get; set; }

        [Display(Name = "Habitaciones")]
        public ICollection<Room>? Rooms { get; set; }

    }
}
