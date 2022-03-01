using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndyHahnCodingExercise.Models
{
    [Table("stores", Schema = "sales")]
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            Stocks = new HashSet<Stock>();
            staff = new HashSet<Staff>();
        }

        [Key]
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("store_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string StoreName { get; set; } = null!;
        [Column("phone")]
        [StringLength(25)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [Column("email")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column("street")]
        [StringLength(255)]
        [Unicode(false)]
        public string? Street { get; set; }
        [Column("city")]
        [StringLength(255)]
        [Unicode(false)]
        public string? City { get; set; }
        [Column("state")]
        [StringLength(10)]
        [Unicode(false)]
        public string? State { get; set; }
        [Column("zip_code")]
        [StringLength(5)]
        [Unicode(false)]
        public string? ZipCode { get; set; }

        [InverseProperty(nameof(Order.Store))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Stock.Store))]
        public virtual ICollection<Stock> Stocks { get; set; }
        [InverseProperty(nameof(Staff.Store))]
        public virtual ICollection<Staff> staff { get; set; }
    }
}
