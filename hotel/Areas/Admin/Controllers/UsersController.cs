using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models.Models;
using Hotel.Models.Context;
using Hotel.Service.Service;
using hotel.Models.ViewModels;
using System.Net;
using System.Data.Entity;
using hotel.Classes;
using Hotel.Classes;

namespace hotel.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private DbHotelContext db = new DbHotelContext();
        UserService _userService;
        RolesService _rolesService;
        public UsersController()
        {
            _userService = new UserService(db);
            _rolesService = new RolesService(db);
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = _userService.GetAll();
            var userViewModels = AutoMapperConfig.mapper.Map<IEnumerable<User>, List<UserViewModel>>(users);

            return View(userViewModels);

        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {

            ViewBag.RoleId = new SelectList(_rolesService.GetAll(), "RoleId", "RoleTittle");
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,RoleId,MobileNumber,Password,IsActive")] UserViewModel usersViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_userService.CheckMobileNumber(usersViewModel.MobileNumber))
                {
                    var users = usersViewModel.ToUsers();
                    users.Password =usersViewModel.Password;
                    users.IsActive = true;
                    users.RegisterDate = DateTime.Now;
                    _userService.Add(users);
                    _userService.Save();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("MobileNumber", "تکراری");
            }

            ViewBag.RoleId = new SelectList(_rolesService.GetAll(), "RoleId", "RoleTittle", usersViewModel.RoleId);
            return View(usersViewModel);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetEntity(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            var userViewModel = AutoMapperConfig.mapper.Map<User, UserViewModel>(user);
            ViewBag.RoleId = new SelectList(_rolesService.GetAll(), "RoleId", "RoleTittle");
            return View(userViewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,RoleId,MobileNumber,Password,IsActive")] UserViewModel userViewModel)
        {
            var user = AutoMapperConfig.mapper.Map<UserViewModel, User>(userViewModel);
            if (ModelState.IsValid)
            {
                _userService.Update(user);
                _userService.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(_rolesService.GetAll(), "RoleId", "RoleTittle");
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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