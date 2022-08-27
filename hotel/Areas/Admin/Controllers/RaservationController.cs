using hotel.Models.ViewModels;
using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hotel.Areas.Admin.Controllers
{
    public class RaservationController : Controller
    {
        private DbHotelContext db = new DbHotelContext();
        RaservationsService _raservationsService;
        UserService _userService;
        RoomsService _roomsService;

        public RaservationController()
        {
            _raservationsService = new RaservationsService(db);
            _userService = new UserService(db);
            _roomsService = new RoomsService(db);
        }


        // GET: Admin/Raservation
        public ActionResult Index()
        {
            var raservation = _raservationsService.GetAll();
            var raservationsViewModel = AutoMapperConfig.mapper.Map<IEnumerable<Raservations>, List<RaservationsViewModel>>(raservation);
            return View(raservationsViewModel);
        }

        // GET: Admin/Raservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Raservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomsGroupTitle , RoomsGroupId , Description")] RaservationsViewModel raservationsViewModel)
        {
            if (ModelState.IsValid)
            {
                Raservations raservations = AutoMapperConfig.mapper.Map<RaservationsViewModel, Raservations>(raservationsViewModel);
                _raservationsService.Add(raservations);
                _raservationsService.Save();
                return RedirectToAction("Index");
            }

            return View(raservationsViewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raservations raservations = _raservationsService.GetEntity(id.Value);
            if (raservations == null)
            {
                return HttpNotFound();
            }
            var raservationsViewModel = AutoMapperConfig.mapper.Map<Raservations, RaservationsViewModel>(raservations);
            return View(raservationsViewModel);
        }


        // GET: Admin/Raservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raservations raservations = _raservationsService.GetEntity(id.Value);
            if (raservations == null)
            {
                return HttpNotFound();
            }
            var raservationViewModel = AutoMapperConfig.mapper.Map<Raservations, RaservationsViewModel>(raservations);
            return View(raservationViewModel);
        }


        // POST: Admin/Raservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InnerDate,OuterDate,CountOfUser,RoomsId,UserId")] RaservationsViewModel raservationsViewModel)
        {
            if (ModelState.IsValid)
            {               
                Raservations raservations = AutoMapperConfig.mapper.Map<RaservationsViewModel, Raservations>(raservationsViewModel);
                _raservationsService.Update(raservations);
                _raservationsService.Save();
                return RedirectToAction("Index");
            }
            return View(raservationsViewModel);
        }

        // GET: Admin/Raservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raservations raservations = _raservationsService.GetEntity(id.Value);
            if (raservations == null)
            {
                return HttpNotFound();
            }
            var raservationsViewModel = AutoMapperConfig.mapper.Map<Raservations, RaservationsViewModel>(raservations);
            return View(raservationsViewModel);
        }

        // POST: Admin/Raservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var raservation = _raservationsService.GetEntity(id);
            _raservationsService.Delete(id);
            _raservationsService.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _raservationsService.Dispose();
        }
    }
}