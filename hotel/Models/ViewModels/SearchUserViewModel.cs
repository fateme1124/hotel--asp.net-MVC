using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace hotel.Models.ViewModels
{
    public class SearchUserViewModel
    {
        [Display(Name = "شماره تلفن همراه")]
        public string MobileNumber  { get; set; }
    }
}