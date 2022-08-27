using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Classes;

namespace hotel.Areas.Admin.Controllers
{
    public class PaymentsController : Controller
    {
        private DbHotelContext db = new DbHotelContext();
        private PaymentsService _paymentsService;
        private UserService _usersService;
        private FactorsService _factorsService;


        public PaymentsController()
        {
            _paymentsService = new PaymentsService(db);
            _factorsService = new FactorsService(db);
            _usersService = new UserService(db);

        }
        //نمایش پرداخت ها 
        public ActionResult Index()
        {

            var payments = _paymentsService.GetAll().OrderBy(t => t.UpdateDate);
            var paymentViewModels = payments.ToPaymentViewModels();
            return View(paymentViewModels);
        }
        //جزئیات پرداخت ها 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = _paymentsService.GetEntity(id.Value);
            if (payments == null)
            {
                return HttpNotFound();
            }
            var paymentViewModel = payments.ToPaymentViewModel();
            return View(paymentViewModel);
        }



        protected override void Dispose(bool disposing)
        {
            _paymentsService.Dispose();
            _factorsService.Dispose();
            _usersService.Dispose();
        }
    }
}