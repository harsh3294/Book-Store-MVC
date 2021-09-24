
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Book_Store.Models
{
    public class BookViewModel
    {
        [HiddenInput]
        public int Book_Id { get; set; }
        [DisplayName("Store Name")]
        public string Store_Id { get; set; }
        [DisplayName("Category Name")]
        public string Category_Id { get; set; }
        [DisplayName("Book Name")]
        public string Book_Name { get; set; }
        [DisplayName("Book Author")]
        public string Book_Author { get; set; }
        [DisplayName("Book Price")]
        public int Book_Price { get; set; }
        [DisplayName("Book Description")]
        public string Book_Description { get; set; }
        [DisplayName("ISBN")]
        public string ISBN_10 { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Language")]
        public string Language { get; set; }
        [DisplayName("Total Pages")]
        public int Total_Pages { get; set; }
        [DisplayName("Book Image")]
        public string Book_Image { get; set; }
        [DisplayName("Publisher Name")]
        public string Publisher_Name { get; set; }
        [DisplayName("Publication Date")]
        public DateTime Publication_Date { get; set; }
    }
}