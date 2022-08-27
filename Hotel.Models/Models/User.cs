using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{
    [Table("T_Users")]
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(15)]
        public string MobileNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
        public virtual ICollection<Factors> Factors { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }

    }
}
