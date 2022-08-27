using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.Models.ViewModels
{
    public class RaservationsViewModel
    {
        [Key]
        [Display(Name = "کد رزرو")]
        public int RaservationId { get; set; }    
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "تاریخ رزرو")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "تاریخ ورود")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        public DateTime InnerDate { get; set; }
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "تاریخ خروج")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        public DateTime OuterDate { get; set; }

        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "تعداد همراه")]
        public string CountOfUser { get; set; }
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "وضعیت کاربر")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "کد اتاق")]
        public int RoomsId { get; set; }

        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        [Display(Name = "کد کاربر")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}