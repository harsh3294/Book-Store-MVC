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
    public class LocationController : Controller
    {
        // GET: User
        Data.Repository.Location location;
        public LocationController()
        {
            location = new Data.Repository.Location(new BookStoreModel());
        }
        public ActionResult Index()
        {
            var locations = location.GetLocations();
            var data = new List<Book_Store.Models.Location>();
            foreach (var c in locations)
            {
                data.Add(Book_Store.Mapper.LocationMapper.Map(c));
            }
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book_Store.Models.Location locationdata)
        {
            location.AddLocation(Book_Store.Mapper.LocationMapper.Map(locationdata));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateLocationById(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var locationData = location.GetLocationById(id);

            if (locationData == null)
            {
                return HttpNotFound();
            }
            return View(Book_Store.Mapper.LocationMapper.Map(locationData));
        }
        [HttpPost]
        public ActionResult UpdateLocationById(int id, Book_Store.Models.Location locationData)
        {
            if (ModelState.IsValid)
            {
                location.UpdateLocationById(id, Book_Store.Mapper.LocationMapper.Map(locationData));
                return RedirectToAction("Index");
            }
            return View(locationData);
        }
        public ActionResult GetLocationById(int id)
        {

            var findLocation = location.GetLocationById(id);
            return View(Book_Store.Mapper.LocationMapper.Map(findLocation));
        }
        public string DeleteLocationById(int id)
        {
            location.DeleteLocationById(id);
            return "Location is successfully deleted";
        }
    }
}