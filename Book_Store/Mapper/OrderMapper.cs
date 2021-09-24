using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class OrderMapper
    {
        public static Book_Store.Models.Order Map(Data.Entities.Order order)
        {
            return new Book_Store.Models.Order()
            {
                OrderId = order.Order_Id,
                bookid = order.Order_Details.Book_Id,
                OrderDetailsid = order.OrderDetails_Id,
                BookName = getBookName(order.Order_Details.Book_Id),
                ImageUrl = getBookImage(order.Order_Details.Book_Id),
                price = getBookPrice(order.Order_Details.Book_Id),
                Quantity = order.Order_Details.Quantity,
                totalPrice = order.Order_Details.Total_Price
            };
        }
        public static string getBookName(int bookid)
        {
            Data.Repository.Book book;
            book = new Data.Repository.Book(new Data.Entities.BookStoreModel());
            var findBook = book.GetBookById(bookid);
            return findBook.Book_Detail.Book_Name;
        }
        public static string getBookImage(int bookid)
        {
            Data.Repository.Book book;
            book = new Data.Repository.Book(new Data.Entities.BookStoreModel());
            var findBook = book.GetBookById(bookid);
            return findBook.Book_Detail.Book_Image;
        }
        public static int getBookPrice(int bookid)
        {
            Data.Repository.Book book;
            book = new Data.Repository.Book(new Data.Entities.BookStoreModel());
            var findBook = book.GetBookById(bookid);
            return findBook.Book_Detail.Book_Price;
        }
    }
}