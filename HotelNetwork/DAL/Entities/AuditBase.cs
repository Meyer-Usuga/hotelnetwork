using System.ComponentModel.DataAnnotations;

namespace HotelNetwork.DAL.Entities
{
    public class AuditBase
    {
        [Key] 
        [Required] 
        public virtual Guid Id { get; set; }       //id generada, totalmente segura     
                                                             
        public virtual DateTime? CreateDate { get; set; }      //fecha de creacion
                                                                
        public virtual DateTime? ModifiedDate { get; set; }   //dia de modificacion
    }
}
