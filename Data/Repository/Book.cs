using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repository
{
    public class Book : IBook
    {
        private BookStoreModel db;
        public Book(BookStoreModel db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Entities.Book> GetBooks()
        {
            return db.Books
                  .Include("Inventory")
                  .Include("Book_Detail")
                  .Include("Publication")
                  .ToList();
        }
        public Data.Entities.Book GetBookById(int id)
        {
            if (id > 0)
            {
                var book = db.Books
                    .Include(i => i.Inventory)
                    .Include(b => b.Book_Detail)
                    .Include(p => p.Publication)
                    .Where(c => c.Book_Id == id)
                    .FirstOrDefault();
                if (book != null)
                    return book;
                else
                {
                    return null;
                }
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }
        public void AddBook(Data.Entities.Book book)
        {
            var inventory = db.Inventories.Add(book.Inventory);
            var publication = db.Publications.Add(book.Publication);
            var bookDetails = db.Book_Detail.Add(book.Book_Detail);
            var bookdata = new Data.Entities.Book()
            {
                BookDetail_Id = bookDetails.Book_Details_Id,
                Publication_Id = publication.Publication_Id,
                Inventory_Id = inventory.Inventory_Id
            };
            db.Books.Add(bookdata);
            save();
        }
        public void UpdateBookById(int id, Data.Entities.Book book)
        {
            var getBook = db.Books.Where<Data.Entities.Book>(u => u.Book_Id == id).First();
            if (getBook != null)
            {
                getBook.Inventory = new Data.Entities.Inventory() { Category_Id = Convert.ToInt32(book.Inventory.Category_Id), Store_Id = Convert.ToInt32(book.Inventory.Store_Id), Quantity = Convert.ToInt32(book.Inventory.Quantity) };
                getBook.Publication = new Data.Entities.Publication() { Publication_Date = book.Publication.Publication_Date, Publisher_Name = book.Publication.Publisher_Name };
                getBook.Book_Detail = new Data.Entities.Book_Detail()
                {
                    Book_Name = book.Book_Detail.Book_Name,
                    Book_Author = book.Book_Detail.Book_Author,
                    Book_Description = book.Book_Detail.Book_Description,
                    Book_Image = book.Book_Detail.Book_Image,
                    Book_Price = book.Book_Detail.Book_Price,
                    ISBN_10 = book.Book_Detail.ISBN_10,
                    Language = book.Book_Detail.Language,
                    Total_Pages = book.Book_Detail.Total_Pages
                };
                /*db.Books.AddOrUpdate(getBook);*/
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Book Found With the id : {book.Book_Id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void DeleteBookById(int id)
        {
            var book = db.Books.Where<Data.Entities.Book>(u => u.Book_Id == id).First();
            var inventory = db.Inventories.Where<Data.Entities.Inventory>(u => u.Inventory_Id == book.Inventory_Id).First();
            var publication = db.Publications.Where<Data.Entities.Publication>(p => p.Publication_Id == book.Publication_Id).First();
            var bookdetail = db.Book_Detail.Where<Data.Entities.Book_Detail>(s => s.Book_Details_Id == book.BookDetail_Id).First();
            if (book != null)
            {
                db.Books.Remove(book);
                db.Inventories.Remove(inventory);
                db.Publications.Remove(publication);
                db.Book_Detail.Remove(bookdetail);
                save();
                return;
            }
            else
            {
                throw new ArgumentException($"No Book Found With the id : {id}");
            }
            throw new ArgumentException("Id cannot be less than 0");
        }
        public void save()
        {
            db.SaveChanges();
        }
        public IEnumerable<Data.Entities.Store> GetStores()
        {
            return db.Stores
                .Include("Location")
                .ToList();
        }
        public IEnumerable<Data.Entities.Category> GetCategories()
        {
            return db.Categories.ToList();
        }
    }
}
