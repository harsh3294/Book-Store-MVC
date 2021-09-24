namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book_Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book_Detail()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Book_Details_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Book_Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Book_Author { get; set; }

        public int Book_Price { get; set; }

        [Required]
        [StringLength(1000)]
        public string Book_Description { get; set; }

        [Required]
        [StringLength(10)]
        public string ISBN_10 { get; set; }

        [Required]
        [StringLength(50)]
        public string Language { get; set; }

        public int Total_Pages { get; set; }

        [Required]
        [StringLength(100)]
        public string Book_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
