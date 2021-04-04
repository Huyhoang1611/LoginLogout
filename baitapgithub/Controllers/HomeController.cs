using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapgithub.Models;

namespace baitapgithub.Controllers
{

    public class HomeController : Controller
    {
        thongtinkhachhangEntities TT = new thongtinkhachhangEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(TT.thongtindangnhap.ToList()); 
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(thongtindangnhap thongtindangnhap)
        {
            if (TT.thongtindangnhap.Any(x => x.Username == thongtindangnhap.Username))
            {
                ViewBag.Nofication = "tai khoan da ton tai";
                return View();
            }
            else
            {
                TT.thongtindangnhap.Add(thongtindangnhap);
                TT.SaveChanges();

                Session["ID"] = thongtindangnhap.ID.ToString();
                Session["Username"] = thongtindangnhap.Username.ToString();
                return RedirectToAction("Index", "Home");


            }
        }
            public ActionResult logout()
            {
                Session.Clear();
                return RedirectToAction("Index", "Home");

            }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(thongtindangnhap thongtindangnhap)
        {
            var checkLogin = TT.thongtindangnhap.Where(x => x.Username.Equals(thongtindangnhap.Username) && x.Passwords.Equals(thongtindangnhap.Passwords)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["ID"] = thongtindangnhap.ID.ToString();
                Session["Username"] = thongtindangnhap.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Ten dang nhap hoac mat khau sai";
            }
            return View();
        }
        }
    }

