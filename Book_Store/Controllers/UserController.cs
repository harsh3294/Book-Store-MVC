using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using Data.Repository;
using System.Net;
using System.Dynamic;

namespace Book_Store.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Data.Repository.User user;
        public UserController()
        {
            user = new Data.Repository.User(new BookStoreModel());
        }
        [HttpGet]
        public ActionResult Index2(Models.UserViewModel model)
        {
            return View(new Models.UserViewModel { Login = new Models.Login(), Register = new Models.Register() });
        }
        [HttpPost]
        public ActionResult Register(Models.Register register)
        {
            TempData["registermessage"] = null;
            user.AddUser(Book_Store.Mapper.UserMapper.Map(register));
            TempData["registermessage"] = "Registered Successfully";
            return RedirectToAction("Index2");
        }
        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            TempData["loginerrormessage"] = null;
            var result = user.userLogin(login.Email, Book_Store.EncryptionDecryption.EncryptionDecryption.EncryptString(login.Password));
            if (result == null)
            {
                TempData["loginerrormessage"] = "Invalid Credentials";
                return RedirectToAction("Index2");
            }
            var role = result.Role_Id;
            if (role == 1)
            {
                Session["UserId"] = result.User_Id;
                Session["FirstName"] = result.FirstName;
                Session["LastName"] = result.LastName;
                return RedirectToAction("Home", "Customer");
            }
            else if (role == 2)
            {
                Session["UserId"] = result.User_Id;
                Session["FirstName"] = result.FirstName;
                Session["LastName"] = result.LastName;
                return RedirectToAction("Index", "Admin");

            }
            return null;
        }
        public ActionResult Index()
        {
            var users = user.GetUsers();
            var data = new List<Book_Store.Models.User>();
            foreach (var c in users)
            {
                data.Add(Book_Store.Mapper.UserMapper.Map(c));
            }
            return View(data);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Book_Store.Models.User userdata)
        {
            user.AddUser(Book_Store.Mapper.UserMapper.Map(userdata));
            return RedirectToAction("Index");
        }
        public ActionResult GetUserById(int id)
        {

            var findUser = user.GetUserById(id);
            return View(Book_Store.Mapper.UserMapper.Map(findUser));
        }
        [HttpGet]
        public ActionResult UpdateUserById(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var userData = user.GetUserById(id);

            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(Book_Store.Mapper.UserMapper.Map(userData));
        }
        [HttpPost]
        public ActionResult UpdateUserById(int id, Book_Store.Models.User userdata)
        {
            if (ModelState.IsValid)
            {
                user.UpdateUserById(id, Book_Store.Mapper.UserMapper.Map(userdata));
                return RedirectToAction("Index");
            }
            return View(userdata);
        }
        public string DeleteUserById(int id)
        {
            user.DeleteUserById(id);
            return "User is successfully deleted";
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index2", "User");
        }


    }
}