using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using Data.Repository;
using System.Net;
namespace Book_Store.Controllers
{
    public class RoleController : Controller
    {
        // GET: User
        Data.Repository.Role role;
        public RoleController()
        {
            role = new Data.Repository.Role(new BookStoreModel());
        }
        public ActionResult Index()
        {
            var roles = role.GetRoles();
            var data = new List<Book_Store.Models.Role>();
            foreach (var c in roles)
            {
                data.Add(Book_Store.Mapper.RoleMapper.Map(c));
            }
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book_Store.Models.Role roledata)
        {
            role.AddRole(Book_Store.Mapper.RoleMapper.Map(roledata));
            return RedirectToAction("Index");
        }

        public ActionResult GetRoleById(int id)
        {
            var findRole = role.GetRoleById(id);
            return View(Book_Store.Mapper.RoleMapper.Map(findRole));
        }

        [HttpGet]
        public ActionResult UpdateRoleById(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var roleData = role.GetRoleById(id);

            if (roleData == null)
            {
                return HttpNotFound();
            }
            return View(Book_Store.Mapper.RoleMapper.Map(roleData));
        }
        [HttpPost]
        public ActionResult UpdateRoleById(int id, Book_Store.Models.Role roledata)
        {
            if (ModelState.IsValid)
            {
                role.UpdateRoleById(id, Book_Store.Mapper.RoleMapper.Map(roledata));
                return RedirectToAction("Index");
            }
            return View(roledata);
        }
        public string DeleteRoleById(int id)
        {
            role.DeleteRoleById(id);
            return "Role is successfully deleted";
        }
    }
}