using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace hotel.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "شماره موبایل")]
        public string MobileNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberPassword { get; set; }
        public string ReturnUrl { get; set; }

    }
}