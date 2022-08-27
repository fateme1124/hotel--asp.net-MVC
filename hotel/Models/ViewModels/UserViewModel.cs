using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Hotel.Models.Models;

namespace hotel.Models.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "کد کاربر")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "نام")]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "نام خانوادگی")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "موبایل")]
        //[RegularExpression("-9(09)[0]{9}", ErrorMessage = "شماره موبایل را صحیح وارد کنید")]
        public string MobileNumber { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "تاریخ ثبت کاربر")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "وضعیت کاربر")]
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public virtual Roles Role { get; set; }
        public virtual ICollection<Factors> Factors { get; set; }
        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}