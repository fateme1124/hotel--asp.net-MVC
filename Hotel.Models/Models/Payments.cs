using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Models
{
    [Table("T_Payments")]
    public class Payments : BaseEntity
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [MaxLength(200)]
        public string TittlePay { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public bool ResultPayment { get; set; }
        [Required]
        public byte ResultCode { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        [Required]
        public DateTime RegisterDate { get; set; }
        [Required]
        [MaxLength(200)]
        public string TransactionCode { get; set; }
        [Required]
        [MaxLength(200)]
        public string RandomFactorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ApIKey { get; set; }
        [Required]
        public int FactorId { get; set; }
        [Required]
        public int RaservationsId { get; set; }

        public virtual Raservations Raservations { get; set; }
        public virtual Factors Factor { get; set; }

    }
}
