
using hotel.Models.ViewModels;
using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hotel.Controllers
{
    public class RoomsesController : Controller
    {
        // GET: Roomses
        DbHotelContext db = new DbHotelContext();
        RoomsGroupService _roomsGroupService;
        RoomsService _roomsService;

        public RoomsesController()
        {
            _roomsGroupService = new RoomsGroupService(db);
            _roomsService = new RoomsService(db);
        }

        public ActionResult ShowRoomsGroup()
        {
            var roomsGroups = _roomsGroupService.GetAll();
            List<RoomsGroupViewModel> roomsGroupViewModels = AutoMapperConfig.mapper.Map<IEnumerable<RoomsGroup>, List<RoomsGroupViewModel>>(roomsGroups);
            return View();
        }

        //public ActionResult RoomsDetails(int id)
        //{
        //    var rooms = _roomsService.GetEntity(id);
        //    if (rooms == null || !rooms.IsActive)
        //    {
        //        return HttpNotFound();
        //    }
        //    _roomsService.Update(rooms);
        //    _roomsService.Save();
        //    RoomsViewModel roomsViewModel = AutoMapperConfig.mapper.Map<Rooms, RoomsViewModel>(rooms);
        //    return View(roomsViewModel);
        //}

    }
}