using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{
    [Table("T_Raservations")]
    public class Raservations : BaseEntity
    { 
        [Key]
        public int RaservationId { get; set; }
 
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public DateTime InnerDate { get; set; }
        [Required]
        public DateTime OuterDate { get; set; }

        [Required]
        public string CountOfUser { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int RoomsId { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
