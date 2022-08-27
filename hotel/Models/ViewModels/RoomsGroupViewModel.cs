using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.Models.ViewModels
{
    public class RoomsGroupViewModel
    {
        [Display(Name = "کد گروه اتاق")]
        public int RoomsGroupId { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "عنوان گروه اتاق")]
        public string RoomsGroupTitle { get; set; }
        [Required]
        [Display(Name = "توضیحات مدل اتاق")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [MaxLength(100)]
        [Display(Name = "تصویر")]
        public string ImageName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual IEnumerable<Rooms> Rooms { get; set; }
    }
}