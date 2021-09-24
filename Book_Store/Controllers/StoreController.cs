using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using System.Net;
using Data.Repository;
namespace Book_Store.Controllers
{
    public class StoreController : Controller
    {
        // GET: User
        Data.Repository.Store store;
        public StoreController()
        {
            store = new Data.Repository.Store(new BookStoreModel());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Location = new SelectList(store.GetLocations(), "Location_Id", "Location_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book_Store.Models.StoreViewModel storedata)
        {
            store.AddStore(Book_Store.Mapper.StoreMapper.Map(storedata));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStoreById(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var storeData = store.GetStoreById(id);

            if (storeData == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Location = new SelectList(store.GetLocations(), "Location_Id", "Location_Name");
                TempData["location"] = storeData.Location_Id;
            }
            return View(Book_Store.Mapper.StoreMapper.MapViewModel(storeData));
        }
        [HttpPost]
        public ActionResult UpdateStoreById(int id, Book_Store.Models.StoreViewModel storeData)
        {
            if (ModelState.IsValid)
            {
                store.UpdateStoreById(id, Book_Store.Mapper.StoreMapper.Map(storeData));
                return RedirectToAction("Index");
            }
            return View(storeData);
        }
        public ActionResult Index()
        {
            var stores = store.GetStores();
            var data = new List<Book_Store.Models.Store>();
            foreach (var c in stores)
            {
                data.Add(Book_Store.Mapper.StoreMapper.Map(c));
            }
            return View(data);
        }
        public ActionResult GetStoreById(int id)
        {

            var findStore = store.GetStoreById(id);
            return View(Book_Store.Mapper.StoreMapper.Map(findStore));
        }

        public string DeleteStoreById(int id)
        {
            store.DeleteStoreById(id);
            return "Store is successfully deleted";
        }
    }
}