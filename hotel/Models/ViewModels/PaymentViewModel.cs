using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Hotel.Models.Models;

namespace Hotel.Models.ViewModels
{
    public class PaymentViewModel
    {
        [Display(Name = "کد پرداخت")]
        public int PaymentId { get; set; }
        [Display(Name = "عنوان پرداخت")]
        [MaxLength(200)]
        public string TittlePay { get; set; }
        [Display(Name = "مبلغ")]
        public int Price { get; set; }
        [Display(Name = "وضعیت پرداخت")]
        public bool ResultPayment { get; set; }
        public byte ResultCode { get; set; }
        [Display(Name = "تاریخ پرداخت نهایی")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        public DateTime UpdateDate { get; set; }
        [Display(Name = "زمان ورود به درگاه")]
        [DisplayFormat(DataFormatString = "{0 : dddd, dd MMMM yyyy}")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = "کد تراکنش")]
        [MaxLength(200)]
        public string TransactionCode { get; set; }
        [MaxLength(200)]
        public string RandomFactorId { get; set; }
        [MaxLength(100)]
        public string ApIKey { get; set; }
        [Display(Name = "کد فاکتور")]
        public int FactorId { get; set; }
        [Display(Name = "کد کاربر")]
        public int RaservationsId { get; set; }

        public virtual Raservations Raservations { get; set; }
        public virtual Factors Factor { get; set; }
    }
}