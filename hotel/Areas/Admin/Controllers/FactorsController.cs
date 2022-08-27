using hotel.Models;
using Hotel.Classes;
using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Models.ViewModels;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hotel.Areas.Admin.Controllers
{
    public class FactorsController : Controller
    {
        private DbHotelContext db = new DbHotelContext();
        private FactorsService _factorsService;

        private UserService _userService;
        public FactorsController()
        {
            _factorsService = new FactorsService(db);
            _userService = new UserService(db);
        }
        // نمایش مدیریت فاکتورها 
        public ActionResult Index()
        {
            return View();
        }
        //نمایش لیست  فاکتور ها 
        public ActionResult ShowIndex()
        {
            var factors = _factorsService.GetAll();
            var factorsViewModels = factors.ToFactorsViewModels();
            return PartialView(factorsViewModels);
        }
        // فاکتور های پرداخت شده یا نشده
        public ActionResult Enable(bool flag)
        {
            var factors = _factorsService.GetAll().Where(t => t.IsFainally == flag);
            var factorsViewModels = factors.ToFactorsViewModels();
            return PartialView("ShowIndex", factorsViewModels);
        }

        //مقدار دهی ویو مدل برای تغییر حالت فعال به غیر فعال و برعکس
        public ActionResult ShowIsFainally(int factorId, bool state)
        {
            var factor = _factorsService.GetEntity(factorId);
            FactorIsFainallyViewModel factorIsFainallyViewModel = new FactorIsFainallyViewModel()
            {
                FactorId = factorId,
                IsFainally = factor.IsFainally,
                FactorState = state
            };
            return PartialView(factorIsFainallyViewModel);
        }

        //تغییر حالت فعال به غیر فعال و برعکس
        public ActionResult ChangeIsFainallyState(int factorId, bool state)
        {
            var factor = _factorsService.GetEntity(factorId);
            factor.IsFainally = state;
            _factorsService.Update(factor);
            _factorsService.Save();
            return RedirectToAction("ShowIsFainally", new { factorId, state });
        }



        // جزئیات فاکتور 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factors factors = _factorsService.GetEntity(id.Value);
            if (factors == null)
            {
                return HttpNotFound();
            }
            var factorsViewModel = factors.ToFactorViewModel();
            return View(factorsViewModel);
        }


        //افزودن فاکتور جدید 
        public ActionResult SearchStudentByMobileNumber()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        //افزودن فاکتور جدید 
        public ActionResult Create(int id)
        {
            //ViewBag.TermId = new SelectList(_termsService.GetAll(), "TermId", "TermName");
            var user = _userService.GetEntity(id);
            ViewBag.User = user;
            FactorsViewModel factorsViewModel = new FactorsViewModel()
            {
                UserId = id
            };
            return View(factorsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FactorId,IsFainally,FainallyDate,Price,Description,UserId,TermId")] FactorsViewModel factorsViewModel)
        {
            if (ModelState.IsValid)
            {
                var factors = factorsViewModel.ToFactor();
                factors.RegisterDate = DateTime.Now;
                factors.FainallyDate = DateTime.Now;
                factors.ValidateTime = Convert.ToInt32(ConfigurationManager.AppSettings["ValidateDay"]);
                factors.RegisterUserId = _userService.GetUserId(User.Identity.Name);
                _factorsService.Add(factors);
                _factorsService.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.TermId = new SelectList(db.Terms, "TermId", "TermName", factorsViewModel.TermId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", factorsViewModel.UserId);

            return View(factorsViewModel);
        }

        // ویرایش فاکتور 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factors factors = _factorsService.GetEntity(id.Value);
            if (factors == null)
            {
                return HttpNotFound();
            }
            var factorsViewModel = factors.ToFactorViewModel();
            //ViewBag.TermId = new SelectList(_termsService.GetAll(), "TermId", "TermName", factorsViewModel.TermId);
            ViewBag.UserId = new SelectList(_userService.GetAll(), "UserId", "Name", factorsViewModel.UserId);
            return View(factorsViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FactorId,IsFainally,ValidateTime,FainallyDate,RegisterDate,Price,RegisterUserId,Description,UserId,TermId")] FactorsViewModel factorsViewModel)
        {
            if (ModelState.IsValid)
            {
                var factors = factorsViewModel.ToFactor();
                _factorsService.Update(factors);
                _factorsService.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.TermId = new SelectList(_termsService.GetAll(), "TermId", "TermName", factorsViewModel.TermId);
            ViewBag.UserId = new SelectList(_userService.GetAll(), "UserId", "Name", factorsViewModel.UserId);
            return View(factorsViewModel);
        }

        // حذف فاکتور 
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factors factors = _factorsService.GetEntity(id.Value);
            var factorsViewModel = factors.ToFactorViewModel();
            if (factors == null)
            {
                return HttpNotFound();
            }
            return View(factorsViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var factors = _factorsService.GetEntity(id);
            _factorsService.Delete(id);
            _factorsService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _factorsService.Dispose();
            _userService.Dispose();
        }
    }
}