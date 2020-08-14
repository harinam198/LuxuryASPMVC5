using DatabaseIO;
using LuxuryStore.Areas.Models;
using LuxuryStore.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace LuxuryStore.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Login(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var db = new DBIO();
        //        var result = db.Login(model.UserName, model.Password);
        //        if (result)
        //        {
        //            var user = db.GetById(model.UserName);
        //            var userSession = new UserLogin();
        //            userSession.UserID = user.ID;
        //            Session.Add(CommomConstants.USER_SESSTION,userSession);

        //            return RedirectToAction("Index", "HomeAD");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Đăng nhập không đúng");
                    
        //        }
        //    }
        //    return View("Index");
        //}

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var db = new DBIO();
                var result = db.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = db.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    Session.Add(CommomConstants.USER_SESSTION, userSession);

                    return RedirectToAction("Index", "HomeAD");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");

                }
            }
            return View("Index");
        }
    }
}