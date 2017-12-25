using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PPC.Models;
using System.Web.Helpers;

namespace PPC.Controllers
{
    public class AccountController : Controller
    {
        DemoPPCRentalEntities db = new DemoPPCRentalEntities();


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.USER.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["UserRole"] = user.Role.ToString();
                    Session["UserIDs"] = user.UserType_ID;
                    Session["Fullname"] = user.FullName;
                    Session["UserID"] = user.ID;
                    if (Session["UserRole"].ToString() == "2")
                    {
                        return RedirectToAction("ViewListMyProject", "AgencyProperty");
                    }
                    return RedirectToAction("ViewListofAgencyProject", "Admin/ProjectAdmin");
                    //Session["FullName"] = user.FullName;
                    //Session["UserID"] = user.ID;
                    //Session["RoleID"] = user.Role;

                    //if (int.Parse(Session["RoleID"].ToString()) == 1)
                    //{
                    //    return RedirectToAction("Index");
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "ProductAdmin", new { area = "Admin" });
                    //}
                }
            }
            else
            {
                ViewBag.mess = "* Account Invalid";
            }
            return View();
        }
        public ActionResult Logout()
        {
            var user = db.USER;
            if (user != null)
            {
                Session["FullName"] = null;
                Session["UserID"] = null;
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(USER user)
        {

            if (ModelState.IsValid)
            {
                var isE = IsEmailExist(user.Email);
                if (isE)
                {
                    ModelState.AddModelError("ExistEmail", "Email đã tồn tại, vui long nhập lại.");
                }
                else
                {
                    user.Password = Crypto.Hash(user.Password);
                    //user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);

                    user.Role = 2;
                    user.Status = true;
                    db.USER.Add(user);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }
        [NonAction]
        public bool IsEmailExist(string email)
        {
            using (DemoPPCRentalEntities da = new DemoPPCRentalEntities())
            {
                var v = da.USER.Where(a => a.Email == email).FirstOrDefault();
                return v != null;
            }
        }

    }
}