using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Store.Models
{
    public class Book
    {
        public int Book_Id { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Store Name")]
        public string Store_Id { get; set; }
        [DisplayName("Category Name")]

        public string Category_Id { get; set; }
        public int Book_Details_Id { get; set; }
        [DisplayName("Book Name")]

        public string Book_Name { get; set; }

        [DisplayName("Author Name")]

        public string Book_Author { get; set; }
        [DisplayName("Book Price")]


        public int Book_Price { get; set; }

        [DisplayName("Description")]

        public string Book_Description { get; set; }
        [DisplayName("ISBN Number")]


        public string ISBN_10 { get; set; }
        [DisplayName("Language")]

        public string Language { get; set; }
        [DisplayName("Total Pages")]

        public int Total_Pages { get; set; }
        [DisplayName("Image Url")]

        public string Book_Image { get; set; }
        [DisplayName("Publisher Name")]

        public string Publisher_Name { get; set; }
        [DisplayName("Publication Date")]

        public DateTime Publication_Date { get; set; }
    }
    public class Inventory
    {
        public int Inventory_Id { get; set; }

        public int Book_Id { get; set; }

        public int Quantity { get; set; }

        public int Store_Id { get; set; }

        public string Category_Id { get; set; }
    }
    public class BookDetails
    {
        public int Book_Details_Id { get; set; }

        public int Book_Id { get; set; }

        public string Book_Name { get; set; }

        public string Book_Author { get; set; }

        public int Book_Price { get; set; }

        public string Book_Description { get; set; }

        public string ISBN_10 { get; set; }

        public string Language { get; set; }

        public int Total_Pages { get; set; }

        public string Book_Image { get; set; }
    }
    public class Publication
    {
        public int Publication_Id { get; set; }
        public string Publisher_Name { get; set; }
        public DateTime Publication_Date { get; set; }
    }
    public class CustomerReview
    {
        public int Customer_Review_Id { get; set; }
        public string Customer_Name { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Rating { get; set; }

        public string Comment { get; set; }

        public int Book_Id { get; set; }
    }
}