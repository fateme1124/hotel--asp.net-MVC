using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{
    [Table("T_RoomsGroups")]
    public class RoomsGroup : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomsGroupId { get; set; }
        [Required]
        [MaxLength(200)]
        public string RoomsGroupTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
