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
    public class RoomsGroupsController : Controller
    {
        // GET: Admin/RoomsGroups

        private DbHotelContext db = new DbHotelContext();
        RoomsGroupService _roomsGroupService;
        public RoomsGroupsController()
        {
            _roomsGroupService = new RoomsGroupService(db);
        }

        public ActionResult Index()
        {
            var roomsGroups = _roomsGroupService.GetAll();
            var roomsGroupViewModels = AutoMapperConfig.mapper.Map<IEnumerable<RoomsGroup>, List<RoomsGroupViewModel>>(roomsGroups);

            return View(roomsGroupViewModels);
        }

        // GET: Admin/RoomsGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomsGroup roomsGroup = _roomsGroupService.GetEntity(id.Value);
            if (roomsGroup == null)
            {
                return HttpNotFound();
            }
            var roomsGroupViewModel = AutoMapperConfig.mapper.Map<RoomsGroup, RoomsGroupViewModel>(roomsGroup);
            return View(roomsGroupViewModel);
        }

        // GET: Admin/RoomsGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RoomsGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomsGroupTitle , RoomsGroupId , Description")] RoomsGroupViewModel roomsGroupViewModel, HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                string imageName = "nophoto.png";
                if (imgUpload != null)
                {
                    imageName = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(imgUpload.FileName);
                    imgUpload.SaveAs(Server.MapPath("/images/rooms-group/") + imageName);
                }
                roomsGroupViewModel.ImageName = imageName;
                roomsGroupViewModel.RoomsGroupId = _roomsGroupService.NextRoomsGroupId();
                RoomsGroup roomsGroup = AutoMapperConfig.mapper.Map<RoomsGroupViewModel, RoomsGroup>(roomsGroupViewModel);
                _roomsGroupService.Add(roomsGroup);
                _roomsGroupService.Save();
                return RedirectToAction("Index");
            }

            return View(roomsGroupViewModel);
        }

        // GET: Admin/RoomsGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomsGroup roomsGroup = _roomsGroupService.GetEntity(id.Value);
            if (roomsGroup == null)
            {
                return HttpNotFound();
            }
            var roomsGroupViewModel = AutoMapperConfig.mapper.Map<RoomsGroup, RoomsGroupViewModel>(roomsGroup);
            return View(roomsGroupViewModel);
        }

        // POST: Admin/RoomsGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomsGroupId,RoomsGroupTitle,ImageName,Description")] RoomsGroupViewModel roomsGroupViewModel, HttpPostedFileBase imgUpload)
        {
            if (ModelState.IsValid)
            {
                if (imgUpload != null)
                {
                    if (roomsGroupViewModel.ImageName != "nophoto.png")
                    {
                        System.IO.File.Delete(Server.MapPath("/images/rooms-group/") + roomsGroupViewModel.ImageName);
                    }
                    else
                    {
                        roomsGroupViewModel.ImageName = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(imgUpload.FileName);
                    }
                    imgUpload.SaveAs(Server.MapPath("/images/rooms-group/") + roomsGroupViewModel.ImageName);
                }
                RoomsGroup roomsGroup = AutoMapperConfig.mapper.Map<RoomsGroupViewModel, RoomsGroup>(roomsGroupViewModel);
                _roomsGroupService.Update(roomsGroup);
                _roomsGroupService.Save();
                return RedirectToAction("Index");
            }
            return View(roomsGroupViewModel);
        }

        // GET: Admin/RoomsGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomsGroup roomsGroup = _roomsGroupService.GetEntity(id.Value);
            if (roomsGroup == null)
            {
                return HttpNotFound();
            }
            var roomsGroupViewModel = AutoMapperConfig.mapper.Map<RoomsGroup, RoomsGroupViewModel>(roomsGroup);
            return View(roomsGroupViewModel);
        }

        // POST: Admin/RoomsNewsGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var roomsGroup = _roomsGroupService.GetEntity(id);
            _roomsGroupService.Delete(id);
            _roomsGroupService.Save();
            if (roomsGroup.ImageName != "nophoto.png")
            {
                System.IO.File.Delete(Server.MapPath("/images/rooms-group/") + roomsGroup.ImageName);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _roomsGroupService.Dispose();
        }
    }
}