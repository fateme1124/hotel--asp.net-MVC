using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{
    [Table("T_Rooms")]
    public class Rooms : BaseEntity
    {
        [Key,Column("ProductRoomsID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomsId { get; set; }
        [Required]
        [MaxLength(300)]
        public string RoomsTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }

        [Required]
        [MaxLength(10)]
        public string PricePerNight { get; set; }

        [Required]
        [MaxLength(10)]
        public string CapacityRoom { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int RoomsGroupId { get; set; }
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual RoomsGroup RoomsGroup { get; set; }
        
        public virtual ICollection<Factors> Factors { get; set; }
    }
}
