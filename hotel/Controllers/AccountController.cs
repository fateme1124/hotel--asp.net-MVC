using hotel.Models.ViewModels;
using Hotel.Models.Context;
using Hotel.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using hotel.Classes;

namespace hotel.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        DbHotelContext db = new DbHotelContext();
        private UserService _userService;
        public AccountController()
        {
            _userService = new UserService(db);
        }

        public ActionResult Login(string returnUrl = "/")
        {
            LoginViewModel login = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "MobileNumber,Password,ReturnUrl,RememberPassword")] LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var password = MainClass.GetSha256(login.Password);
                var user = _userService.GetAll().FirstOrDefault(t => t.MobileNumber == login.MobileNumber && t.Password == login.Password);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        if (user.RoleId == 1)
                        {
                            FormsAuthentication.SetAuthCookie(login.MobileNumber, login.RememberPassword);
                            return Redirect(login.ReturnUrl);
                        }
                        ModelState.AddModelError("MobileNumber", "فقط مدیر سامانه مجاز به ورود به پنل می باشد");
                    }
                    ModelState.AddModelError("MobileNumber", "حساب کاربری شما فعال نمی باشد");
                }
                ModelState.AddModelError("MobileNumber", "نام کاربری یا رمز عبور شما اشتباه است");
                return View();
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }


        public ActionResult LoginState()
        {
            ViewBag.LoginState = false;
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.LoginState = true;
            }
            return PartialView();
        }
       
    }
}