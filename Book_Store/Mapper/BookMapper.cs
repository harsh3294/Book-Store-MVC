using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book_Store.Mapper
{
    public class BookMapper
    {
        public static Book_Store.Models.Book Map(Data.Entities.Book book)
        {
            return new Book_Store.Models.Book()
            {
                Book_Id = book.Book_Id,
                Category_Id = book.Inventory.Category.Category_Name,
                Store_Id = book.Inventory.Store.Store_Name,
                Quantity = book.Inventory.Quantity,
                Book_Details_Id = book.BookDetail_Id,
                Book_Name = book.Book_Detail.Book_Name,
                Book_Author = book.Book_Detail.Book_Author,
                Book_Description = truncate(book.Book_Detail.Book_Description),
                Book_Image = book.Book_Detail.Book_Image,
                Book_Price = book.Book_Detail.Book_Price,
                ISBN_10 = book.Book_Detail.ISBN_10,
                Language = book.Book_Detail.Language,
                Total_Pages = book.Book_Detail.Total_Pages,
                Publisher_Name = book.Publication.Publisher_Name,
                Publication_Date = book.Publication.Publication_Date,
            };
        }
        public static string truncate(string desc, int n = 150)
        {
            return (desc.Length > n ? desc.Substring(0, n - 1) + "..." : desc);
        }
        public static Book_Store.Models.Book Map2(Data.Entities.Book book)
        {
            return new Book_Store.Models.Book()
            {
                Book_Id = book.Book_Id,
                Category_Id = book.Inventory.Category.Category_Name,
                Store_Id = book.Inventory.Store.Store_Name,
                Quantity = book.Inventory.Quantity,
                Book_Details_Id = book.BookDetail_Id,
                Book_Name = book.Book_Detail.Book_Name,
                Book_Author = book.Book_Detail.Book_Author,
                Book_Description = book.Book_Detail.Book_Description,
                Book_Image = book.Book_Detail.Book_Image,
                Book_Price = book.Book_Detail.Book_Price,
                ISBN_10 = book.Book_Detail.ISBN_10,
                Language = book.Book_Detail.Language,
                Total_Pages = book.Book_Detail.Total_Pages,
                Publisher_Name = book.Publication.Publisher_Name,
                Publication_Date = DateTime.Parse(book.Publication.Publication_Date.ToString())
            };
        }
        public static Book_Store.Models.BookViewModel MapBookViewModel(Data.Entities.Book book)
        {
            return new Book_Store.Models.BookViewModel()
            {
                Book_Id = book.Book_Id,
                Category_Id = book.Inventory.Category.Category_Name,
                Store_Id = book.Inventory.Store.Store_Name,
                Quantity = book.Inventory.Quantity,
                Book_Name = book.Book_Detail.Book_Name,
                Book_Author = book.Book_Detail.Book_Author,
                Book_Description = book.Book_Detail.Book_Description,
                Book_Image = book.Book_Detail.Book_Image,
                Book_Price = book.Book_Detail.Book_Price,
                ISBN_10 = book.Book_Detail.ISBN_10,
                Language = book.Book_Detail.Language,
                Total_Pages = book.Book_Detail.Total_Pages,
                Publisher_Name = book.Publication.Publisher_Name,
                Publication_Date = book.Publication.Publication_Date,
            };
        }
        public static Data.Entities.Book MapDataEntities(Book_Store.Models.BookViewModel book)
        {
            return new Data.Entities.Book()
            {
                Inventory = new Data.Entities.Inventory() { Category_Id = Convert.ToInt32(book.Category_Id), Store_Id = Convert.ToInt32(book.Store_Id), Quantity = Convert.ToInt32(book.Quantity) },
                Publication = new Data.Entities.Publication() { Publication_Date = book.Publication_Date, Publisher_Name = book.Publisher_Name },
                Book_Detail = new Data.Entities.Book_Detail()
                {
                    Book_Name = book.Book_Name,
                    Book_Author = book.Book_Author,
                    Book_Description = book.Book_Description,
                    Book_Image = book.Book_Image,
                    Book_Price = book.Book_Price,
                    ISBN_10 = book.ISBN_10,
                    Language = book.Language,
                    Total_Pages = book.Total_Pages
                }
            };
        }

    }
}