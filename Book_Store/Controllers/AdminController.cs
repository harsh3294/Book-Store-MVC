using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using Data.Repository;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Dynamic;
using System.Text;
namespace Book_Store.Controllers
{
    public class AdminController : Controller
    {
        // GET: User
        Data.Repository.User user;
        Data.Repository.Store store;
        Data.Repository.Location location;
        Data.Repository.Category category;
        Data.Repository.Book book;
        Data.Repository.OrderRepository order;
        public AdminController()
        {
            user = new Data.Repository.User(new BookStoreModel());
            store = new Data.Repository.Store(new BookStoreModel());
            location = new Data.Repository.Location(new BookStoreModel());
            category = new Data.Repository.Category(new BookStoreModel());
            book = new Data.Repository.Book(new Data.Entities.BookStoreModel());
            order = new Data.Repository.OrderRepository(new Data.Entities.BookStoreModel());
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrderHistory()
        {
            var data = order.getAllOrders();
            var data2 = new List<Book_Store.Models.OrderHistory>();
            foreach (var d in data)
            {
                data2.Add(Book_Store.Mapper.OrderHistoryMapper.Map(d));
            }
            return View(data2);
        }


        public ActionResult GetBooks()
        {
            var books = book.GetBooks();
            var data = new List<Book_Store.Models.Book>();
            foreach (var c in books)
            {
                data.Add(Book_Store.Mapper.BookMapper.Map(c));
            }
            return View(data);
        }
        public ActionResult GetBookById(int id)
        {

            var findBook = book.GetBookById(id);
            return View(Book_Store.Mapper.BookMapper.Map(findBook));
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.Store = new SelectList(book.GetStores(), "Store_Id", "Store_Name");
            ViewBag.Category = new SelectList(book.GetCategories(), "Category_Id", "Category_Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book_Store.Models.BookViewModel bookData)
        {
            book.AddBook(Book_Store.Mapper.BookMapper.MapDataEntities(bookData));
            return RedirectToAction("GetBooks");
        }


        [HttpGet]
        public ActionResult UpdateBookById(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var bookdata = book.GetBookById(id);

            if (bookdata == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Store = new SelectList(book.GetStores(), "Store_Id", "Store_Name");
                ViewBag.Category = new SelectList(book.GetCategories(), "Category_Id", "Category_Name");
                TempData["Store"] = bookdata.Inventory.Store_Id;
                TempData["Category"] = bookdata.Inventory.Category_Id;

            }
            return View(Book_Store.Mapper.BookMapper.MapBookViewModel(bookdata));
        }
        [HttpPost]
        public ActionResult UpdateBookById(int id, Book_Store.Models.BookViewModel bookData)
        {
            if (ModelState.IsValid)
            {
                book.UpdateBookById(id, Book_Store.Mapper.BookMapper.MapDataEntities(bookData));
                return RedirectToAction("GetBooks");
            }
            return View(bookData);
        }

        public string DeleteBookById(int id)
        {
            book.DeleteBookById(id);
            return "Book is successfully deleted";
        }






        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Book_Store.Models.Category categoryData)
        {
            category.AddCategory(Book_Store.Mapper.CategoryMapper.Map(categoryData));
            return RedirectToAction("GetCategory");
        }
        public ActionResult GetCategory()
        {
            var categories = category.GetCategories();
            var data = new List<Book_Store.Models.Category>();
            foreach (var c in categories)
            {
                data.Add(Book_Store.Mapper.CategoryMapper.Map(c));
            }
            return View(data);
        }
        public ActionResult GetCategoryById(int id)
        {

            var findCategory = category.GetCategoryById(id);
            return View(Book_Store.Mapper.CategoryMapper.Map(findCategory));
        }
        [HttpGet]
        public ActionResult UpdateCategoryById(int id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var categoryData = category.GetCategoryById(id);

            if (categoryData == null)
            {
                return HttpNotFound();
            }
            return View(Book_Store.Mapper.CategoryMapper.Map(categoryData));
        }
        [HttpPost]
        public ActionResult UpdateCategoryById(int id, Book_Store.Models.Category categoryData)
        {
            if (ModelState.IsValid)
            {
                category.UpdateCategoryById(id, Book_Store.Mapper.CategoryMapper.Map(categoryData));
                return RedirectToAction("GetCategory");
            }
            return View(categoryData);
        }
        public string DeleteCategoryById(int id)
        {
            category.DeleteCategoryById(id);
            return "Category is successfully deleted";
        }
        public ActionResult GetLocation()
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
        public ActionResult AddLocation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLocation(Book_Store.Models.Location locationdata)
        {
            location.AddLocation(Book_Store.Mapper.LocationMapper.Map(locationdata));
            return RedirectToAction("GetLocation");
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
                return RedirectToAction("GetLocation");
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
        [HttpGet]
        public ActionResult AddStore()
        {
            ViewBag.Location = new SelectList(store.GetLocations(), "Location_Id", "Location_Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddStore(Book_Store.Models.StoreViewModel storedata)
        {
            store.AddStore(Book_Store.Mapper.StoreMapper.Map(storedata));
            return RedirectToAction("GetStore");
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
                return RedirectToAction("GetStore");
            }
            return View(storeData);
        }
        public ActionResult GetStore()
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
        public ActionResult UserInfo()
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
            return RedirectToAction("UserInfo");
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
                return RedirectToAction("UserInfo");
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