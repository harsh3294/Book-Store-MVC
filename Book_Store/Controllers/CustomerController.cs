using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Entities;
using System.Net;

namespace Book_Store.Controllers
{
    public class CustomerController : Controller
    {
        Data.Repository.Book book;
        Data.Repository.OrderRepository order;

        public CustomerController()
        {
            book = new Data.Repository.Book(new Data.Entities.BookStoreModel());
            order = new Data.Repository.OrderRepository(new Data.Entities.BookStoreModel());
        }
        public ActionResult OrderHistory()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var data = order.getAllOrders(userid);
            var data2 = new List<Book_Store.Models.OrderHistory>();
            foreach (var d in data)
            {
                data2.Add(Book_Store.Mapper.OrderHistoryMapper.Map(d));
            }
            return View(data2);
        }
        public ActionResult Checkout()
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var result = order.migrateData(userid);
            if (result == true)
            {
                return RedirectToAction("Home");
            }
            return Content("<script language='javascript' type='text/javascript'>Checkout Not Completed Properly</script>");
        }




        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Home()
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
            return View(Book_Store.Mapper.BookMapper.Map2(findBook));
        }
        /* [HttpPost]*/
        public ActionResult AddToCart(int id)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            order.AddOrder(id, userid);
            return RedirectToAction("Home");
        }
        public ActionResult UpdateCartProduct(int id, int qty, int bookid)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            order.updateOrder(bookid, userid, qty);
            return RedirectToAction("ViewCart");
        }
        public ActionResult DaleteCartProduct(int id)
        {
            order.deleteProduct(id);
            return RedirectToAction("ViewCart");
        }
        public ActionResult ViewCart()
        {
            int userid = Convert.ToInt32(Session["UserId"]);

            var cart = order.getOrderByUser(userid);
            var data = new List<Book_Store.Models.Order>();
            int totalPrice = 0;
            foreach (var c in cart)
            {
                data.Add(Book_Store.Mapper.OrderMapper.Map(c));
            }
            foreach (var d in data)
            {
                totalPrice = totalPrice + d.totalPrice;
            }
            TempData["TotalPrice"] = totalPrice;
            TempData["count"] = data.Count();
            return View(data);
        }
    }
}