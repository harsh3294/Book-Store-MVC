using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Entities;
using System.Net;
namespace Book_Store.Controllers
{
    public class BookController : Controller
    {
        // GET: User
        Data.Repository.Book book;
        public BookController()
        {
            book = new Data.Repository.Book(new Data.Entities.BookStoreModel());
        }
        public ActionResult Index()
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
        public ActionResult Create()
        {
            ViewBag.Store = new SelectList(book.GetStores(), "Store_Id", "Store_Name");
            ViewBag.Category = new SelectList(book.GetCategories(), "Category_Id", "Category_Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book_Store.Models.BookViewModel bookData)
        {
            book.AddBook(Book_Store.Mapper.BookMapper.MapDataEntities(bookData));
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
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
        public ActionResult Edit(int id, Book_Store.Models.BookViewModel bookData)
        {
            if (ModelState.IsValid)
            {
                book.UpdateBookById(id, Book_Store.Mapper.BookMapper.MapDataEntities(bookData));
                return RedirectToAction("Index");
            }
            return View(bookData);
        }

        public string DeleteBookById(int id)
        {
            book.DeleteBookById(id);
            return "Book is successfully deleted";
        }
    }
}