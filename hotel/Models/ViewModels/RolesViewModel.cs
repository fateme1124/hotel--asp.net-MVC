using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models.ViewModels
{
    public class RolesViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "کد نقش")]
        public byte RoleId { get; set; }
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [MaxLength(100)]
        [Display(Name = "نام نقش")]
        public string RoleTittle { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}