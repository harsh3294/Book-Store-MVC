using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entities
{
    public partial class BookStoreModel : DbContext
    {
        public BookStoreModel()
            : base("name=BookStoreModel")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Book_Detail> Book_Detail { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer_Review> Customer_Review { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Details> Order_Details { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.OrderHistories)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.Book_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.Book_Author)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.Book_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.ISBN_10)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .Property(e => e.Book_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Book_Detail>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Book_Detail)
                .HasForeignKey(e => e.BookDetail_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Category_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer_Review>()
                .Property(e => e.Customer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer_Review>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Inventory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Location_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Stores)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order_Details>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Order_Details)
                .HasForeignKey(e => e.OrderDetails_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publication>()
                .Property(e => e.Publisher_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Publication>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Publication)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Role_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Store_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
