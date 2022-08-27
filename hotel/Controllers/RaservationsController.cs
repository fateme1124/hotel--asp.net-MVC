using hotel.Classes;
using Hotel.Models.ViewModels;
using Hotel.Classes;
using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotel.Models.ViewModels;

namespace hotel.Controllers
{
    public class RaservationsController : Controller
    {
        // GET: Raservations
        private DbHotelContext db = new DbHotelContext();
        RaservationsService _raservationsService;
        UserService _userService;
        RolesService _rolesService;
        RoomsService _roomsService;

        public RaservationsController()
        {
            _raservationsService = new RaservationsService(db);
            _userService = new UserService(db);
            _rolesService = new RolesService(db);
            _roomsService = new RoomsService(db);
        }        

        // GET: Raservations/FormInput
        public ActionResult FormInput()
        {
            return View();
        }

        // POST:Raservations/FormInput
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormInput([Bind(Include = "UserId,FirstName,LastName,RoleId,MobileNumber,Password,IsActive")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                //User users = usersViewModel.ToUsers();
                User user = AutoMapperConfig.mapper.Map<UserViewModel, User>(userViewModel);
                user.IsActive = true;
                user.RegisterDate = DateTime.Now;
                user.RoleId = 2;
                user.Password = "1234";
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("ShowRaservations");
            }
            ////////////////////////////
            //if (ModelState.IsValid)
            //{
            //    if (!_userService.CheckMobileNumber(userViewModel.MobileNumber))
            //    {
            //        var users = userViewModel.ToUsers();
            //        users.Password = "123";
            //        users.IsActive = true;
            //        users.RoleId = 2;
            //        users.RegisterDate = DateTime.Now;
            //        _userService.Add(users);
            //        _userService.Save();
            //        return RedirectToAction("ShowRaservations");
            //    }
            //    ModelState.AddModelError("MobileNumber", "تکراری");
            //}
            /////////////////////////
            return View(userViewModel);
        }

        public ActionResult SelectRooms()
        {
            var Rooms=_roomsService.GetAll().Where(t => t.IsActive).ToList();
            
            List<RoomsViewModel> roomsViewModels = AutoMapperConfig.mapper.Map<IEnumerable<Rooms>, List<RoomsViewModel>>(Rooms);
           
            return PartialView(roomsViewModels);
        }

        // GET : Raservations/ShowRaservations
        public ActionResult ShowRaservations(/*int id*/)  //id user
        {
            //var raservationsViewModel = new RaservationsViewModel();
            //raservationsViewModel.UserId = id;
            /*return View(raservationsViewModel)*/;
            return View();
        }

        // POST : Raservations/ShowRaservations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowRaservations([Bind(Include = "RaservationsId,UserId,InnerDate, OuterDate , CountOfUser, RoomsId")] RaservationsViewModel raservationsViewModel)
        {
            if (ModelState.IsValid)
            {
                Raservations raservations = AutoMapperConfig.mapper.Map<RaservationsViewModel, Raservations>(raservationsViewModel);
                //raservations.UserId = _userService.GetUserId(User.Identity.Name);
                int user = _userService.GetAll().Select(t => t.UserId).Max();
                raservations.UserId = user;
                raservations.IsActive = true;
                raservations.RegisterDate = DateTime.Now;
                _raservationsService.Add(raservations);
                _raservationsService.Save();
                return View("FainalyDate");
            }
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "MobileNumber", raservationsViewModel.UserId);
            return View(raservationsViewModel);
        }

        public ActionResult FainalyDate(int ? id) //id=RaservationId
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
            raservations.IsActive = true;
            raservations.RegisterDate = DateTime.Now;
            RaservationsViewModel raservationsViewModel = AutoMapperConfig.mapper.Map<Raservations, RaservationsViewModel>(raservations);
            return View(raservationsViewModel);

            //int RaservationsId = _raservationsService.GetAll().Select(t => t.RaservationId).Max();
            //var users = _raservationsService.GetAll().GroupBy(t => t.RaservationId = RaservationsId);
            //var user = _userService.GetEntity(RaservationsId);
            //var raservationsViewModel = AutoMapperConfig.mapper.Map<Raservations, RaservationsViewModel>(user);          
        }

        public ActionResult Bank()
        {
            return View();
        }

        public ActionResult Payments()
        {

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
