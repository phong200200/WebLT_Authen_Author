    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebLT_Authen_Author.DAL;
using WebLT_Authen_Author.Models;


namespace WebLT_Authen_Author.Controllers
{
    public class RegisterController : Controller
    {

        public readonly UserContext db = new UserContext();

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }


        // GET: Register
        public ActionResult Index()
        {
            foreach(var user in db.users)
            {
                user.Password = GetMD5(user.Password);
            }
            return View(db.users.ToList());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var checker = db.users.SingleOrDefault(u => u.Email == user.Email);
                if (checker == null) 
                {
                    user.Password = GetMD5(user.Password);
                    db.users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email are not available @.o";
                }

            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            user.Password = GetMD5(user.Password);

            var UserChecker = db.users.FirstOrDefault(a => a.UserName == user.UserName && a.Password == user.Password);
            if(UserChecker != null)
            {
                
                //Session lưu phiên đăng nhập
                Session["UserID"] = UserChecker.UserID.ToString();
                Session["UserName"] = UserChecker.UserName.ToString();
                return RedirectToAction("Loggedin");

            }
            else
            {
                ModelState.AddModelError("","Login không success");
            }


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Loggedin()
        {
            if (Session["UserID"] != null)
            {
                return View();  
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}