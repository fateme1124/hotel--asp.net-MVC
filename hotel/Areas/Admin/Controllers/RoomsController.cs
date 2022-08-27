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
    public class RoomsController : Controller
    {
        // GET: Admin/Rooms
        private DbHotelContext db = new DbHotelContext();
        private RoomsService _roomsService;
        private RoomsGroupService _roomsGroupService;
        private UserService _userService;
        public RoomsController()
        {
            _roomsService = new RoomsService(db);
            _roomsGroupService = new RoomsGroupService(db);
            _userService = new UserService(db);
        }
        // GET: Admin/Rooms
        public ActionResult Index()
        {
            var rooms = _roomsService.GetAll();
            var roomsViewModel = AutoMapperConfig.mapper.Map<IEnumerable<Rooms>, List<RoomsViewModel>>(rooms);
            return View(roomsViewModel);
        }

        // GET: Admin/Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = _roomsService.GetEntity(id.Value);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            RoomsViewModel roomsViewModel = AutoMapperConfig.mapper.Map<Rooms, RoomsViewModel>(rooms);
            return View(roomsViewModel);
        }

        // GET: Admin/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.RoomsGroupId = new SelectList(_roomsGroupService.GetAll(), "RoomsGroupId", "RoomsGroupTitle");
            return View();
        }

        // POST: Admin/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomsId,RoomsTitle,Description,RoomsGroupId,PricePerNight,CapacityRoom")] RoomsViewModel roomsViewModel,
                                HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                #region  save Image to Server
                string imageName = "nophoto.png";
                if (imgUpload != null)
                {
                    imageName = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(imgUpload.FileName);
                    imgUpload.SaveAs(Server.MapPath("/images/rooms/") + imageName);
                }
                #endregion

                roomsViewModel.ImageName = imageName;
                var rooms = AutoMapperConfig.mapper.Map<RoomsViewModel, Rooms>(roomsViewModel);
                rooms.IsActive = true;
                rooms.RegisterDate = DateTime.Now;
                roomsViewModel.RoomsId = _roomsService.NextRoomsId();
                _roomsService.Add(rooms);
                _roomsService.Save();
                return RedirectToAction("Index");
            }

            ViewBag.RoomsGroupId = new SelectList(db.RoomsGroup, "RoomsGroupId", "RoomsGroupTitle", roomsViewModel.RoomsGroupId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "MobileNumber", roomsViewModel.UserId);
            return View(roomsViewModel);
        }





        // GET: Admin/Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = _roomsService.GetEntity(id.Value);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            RoomsViewModel roomsViewModel = AutoMapperConfig.mapper.Map<Rooms, RoomsViewModel>(rooms);
            ViewBag.RoomsGroupId = new SelectList(_roomsGroupService.GetAll(), "RoomsGroupId", "RoomsGroupTitle", rooms.RoomsGroupId);
            return View(roomsViewModel);
        }

        // POST: Admin/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomsId,RoomsTitle,Description,ImageName,RoomsGroupId,PricePerNight,CapacityRoom")] RoomsViewModel roomsViewModel,
            HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                if (imgUpload != null)
                {
                    if (roomsViewModel.ImageName != "nophoto.png")
                    {
                        System.IO.File.Delete(Server.MapPath("/images/rooms/") + roomsViewModel.ImageName);
                    }
                    else
                    {
                        roomsViewModel.ImageName = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(imgUpload.FileName);
                    }
                    imgUpload.SaveAs(Server.MapPath("/images/rooms/") + roomsViewModel.ImageName);
                }

                Rooms rooms = AutoMapperConfig.mapper.Map<RoomsViewModel, Rooms>(roomsViewModel);

                _roomsService.Update(rooms);
                _roomsService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RoomsGroupId = new SelectList(_roomsGroupService.GetAll(), "RoomsGroupId", "RoomsGroupTitle", roomsViewModel.RoomsGroupId);
            return View(roomsViewModel);
        }

        // GET: Admin/Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rooms rooms = _roomsService.GetEntity(id.Value);
            RoomsViewModel roomsViewModel = AutoMapperConfig.mapper.Map<Rooms, RoomsViewModel>(rooms);
            if (rooms == null)
            {
                return HttpNotFound();
            }
            return View(roomsViewModel);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var rooms = _roomsService.GetEntity(id);
            _roomsService.Delete(id);
            _roomsService.Save();

            if (rooms.ImageName != "nophoto.png")
            {
                System.IO.File.Delete(Server.MapPath("/images/rooms/") + rooms.ImageName);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _roomsService.Dispose();
            _roomsGroupService.Dispose();
            _userService.Dispose();
        }
    }
}