using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Models.ViewModels
{
    public class RoomsViewModel
    {
        [Display(Name = "کد اتاق")]
        public int RoomsId { get; set; }
        [Required]
        [MaxLength(300)]
        [Display(Name = "نام اتاق")]
        public string RoomsTitle { get; set; }
        [Required]
        [Display(Name = "امکانات اتاق")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Description { get; set; }
        [MaxLength(100)]
        [Display(Name = "تصویر اتاق")]
        public string ImageName { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = " قیمت اتاق برای یک شب")]
        public string PricePerNight { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "ظرفیت اتاق ")]
        public string CapacityRoom { get; set; }
        [Display(Name = "تاریخ درج")]
        [DisplayFormat(DataFormatString = "{0: dddd, dd MMMM yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "فعال/غیرفعال")]
        public bool IsActive { get; set; }
        [Display(Name = "نوع اتاق")]
        public int RoomsGroupId { get; set; }
        [Display(Name = "کاربر ثبت کننده")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual RoomsGroup RoomsGroup { get; set; }
        public virtual ICollection<Factors> Factors { get; set; }
    }
}