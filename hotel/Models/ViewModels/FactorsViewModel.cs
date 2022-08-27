using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.ViewModels
{
    public class FactorsViewModel
    {
        [Display(Name = "کد فاکتور")]
        public int FactorId { get; set; }
       
        [Display(Name = "وضعیت پرداخت")]
        public bool IsFainally { get; set; }
        [Display(Name = "تاریخ اعتبار")]  
        public int ValidateTime { get; set; }
        [Display(Name = "تاریخ پرداخت")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public DateTime FainallyDate { get; set; }
        [Display(Name = "تاریخ  درخواست")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public int Price { get; set; }
        [Display(Name = "مدیر ثبت کننده")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public int RegisterUserId { get; set; }
        [MaxLength(500)]
        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public string Description { get; set; }
        [Display(Name = "کد کاربر")]
        [Required(ErrorMessage = "فیلد {0} نمی تواند خالی باشد.")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}