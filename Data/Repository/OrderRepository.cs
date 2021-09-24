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
    public class OrderRepository
    {
        private BookStoreModel db;
        public OrderRepository(BookStoreModel db)
        {
            this.db = db;
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

        public IEnumerable<Data.Entities.OrderHistory> getAllOrders(int userid)
        {
            var data = db.OrderHistories.Include("Book").Where(c => c.userid == userid).ToList();
            return data;
        }
        public IEnumerable<Data.Entities.OrderHistory> getAllOrders()
        {
            var data = db.OrderHistories.Include("Book").ToList();
            return data;
        }
        public bool migrateData(int userid)
        {
            var orderdetails = getOrderByUser(userid);
            foreach (var data in orderdetails)
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                var orderhistory = new Data.Entities.OrderHistory()
                {
                    userid = userid,
                    Book_Id = data.Order_Details.Book_Id,
                    Quantity = data.Order_Details.Quantity,
                    Total_Price = data.Order_Details.Total_Price,
                    date = DateTime.Parse(dateTime.ToString("dd/MM/yyyy"))
                };
                db.OrderHistories.Add(orderhistory);
                deleteProduct(data.OrderDetails_Id);
            }
            save();
            return true;
        }

        public IEnumerable<Data.Entities.Order> getOrderByUser(int userid)
        {
            return db.Orders.Include("Order_Details").Where(c => c.User_Id == userid).ToList();
        }
        public void AddOrder(int id, int userid)
        {
            var findbook = GetBookById(id);
            Data.Entities.Order_Details findorderdetail = null;
            var findorder = db.Orders.Include("Order_Details").Where(c => c.User_Id == userid && c.Order_Details.Book_Id == id).FirstOrDefault();
            /* foreach (var order in findorder)
             {
                 findorderdetail = db.Order_Details.Where(p => p.Order_Details_Id == order.OrderDetails_Id && p.Book_Id == id).FirstOrDefault();
             }*/
            if (findorder == null)
            {
                if (findbook != null)
                {
                    var orderdetail = new Data.Entities.Order_Details()
                    {
                        Store_Id = findbook.Inventory.Store_Id,
                        Book_Id = findbook.Book_Id,
                        Quantity = 1,
                        Total_Price = findbook.Book_Detail.Book_Price
                    };
                    db.Order_Details.Add(orderdetail);
                    save();
                    var order = new Data.Entities.Order()
                    {
                        OrderDetails_Id = orderdetail.Order_Details_Id,
                        User_Id = userid,
                        Total_Price = findbook.Book_Detail.Book_Price
                    };
                    db.Orders.Add(order);
                    save();
                }
            }
            else
            {
                updateOrder2(id, userid);
            }

        }
        public void updateOrder2(int id, int userid)
        {
            int qty = 1;
            var findbook = GetBookById(id);
            var findorder = db.Orders.Include("Order_Details").Where(c => c.User_Id == userid).ToList();
            foreach (var order in findorder)
            {
                var findorderdetail = db.Order_Details.Where(p => p.Order_Details_Id == order.OrderDetails_Id && p.Book_Id == id).FirstOrDefault();
                if (findorderdetail != null)
                {
                    findorderdetail.Quantity = qty + findorderdetail.Quantity;
                    int total = findbook.Book_Detail.Book_Price * qty;
                    int totalPrice = findorderdetail.Total_Price + total;
                    findorderdetail.Total_Price = totalPrice;
                }
            }
            save();
        }
        public void updateOrder(int id, int userid, int qty = 1)
        {
            var findbook = GetBookById(id);
            var findorder = db.Orders.Include("Order_Details").Where(c => c.User_Id == userid).ToList();
            foreach (var order in findorder)
            {
                var findorderdetail = db.Order_Details.Where(p => p.Order_Details_Id == order.OrderDetails_Id && p.Book_Id == id).FirstOrDefault();
                if (findorderdetail != null)
                {
                    findorderdetail.Quantity = qty;
                    findorderdetail.Total_Price = findbook.Book_Detail.Book_Price * qty;
                }
            }
            save();
        }
        public void deleteProduct(int orderdetails)
        {
            var findorder = db.Orders.Where(p => p.OrderDetails_Id == orderdetails).FirstOrDefault();
            var findorderdetail = db.Order_Details.Where(p => p.Order_Details_Id == orderdetails).FirstOrDefault();

            db.Orders.Remove(findorder);
            db.Order_Details.Remove(findorderdetail);
            save();
        }
        public void save()
        {
            db.SaveChanges();
        }
    }
}
