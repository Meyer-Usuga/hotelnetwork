using System.ComponentModel.DataAnnotations;

namespace HotelNetwork.DAL.Entities
{
    public class AuditBase
    {
        [Key] 
        [Required] 
        public virtual Guid Id { get; set; }       
                                                             
        public virtual DateTime? CreateDate { get; set; }      
                                                                
        public virtual DateTime? ModifiedDate { get; set; }   
    }
}
