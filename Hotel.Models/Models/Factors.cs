using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{

    [Table("T_Factors")]
    public class Factors : BaseEntity
    {
        [Key]
        public int FactorId { get; set; }
        [Required]
        public bool IsFainally { get; set; }
        [Required]
        public int ValidateTime { get; set; }
        [Required]
        public DateTime FainallyDate { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int RegisterUserId { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoomsId { get; set; }

        public virtual User User { get; set; }
        public virtual Rooms Rooms { get; set; }

    }
}
