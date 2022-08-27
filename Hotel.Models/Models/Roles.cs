using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{
    [Table("T_Roles")]
    public class Roles : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte RoleId { get; set; }
        [Required]
        [MaxLength(100)]
        public string RoleTittle { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
