namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Details()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Order_Details_Id { get; set; }

        public int Store_Id { get; set; }

        public int Book_Id { get; set; }

        public int Quantity { get; set; }

        public int Total_Price { get; set; }

        public virtual Book Book { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Store Store { get; set; }
    }
}
