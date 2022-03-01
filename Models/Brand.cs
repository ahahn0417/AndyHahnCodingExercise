using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndyHahnCodingExercise.Models
{
    [Table("brands", Schema = "production")]
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("brand_id")]
        public int BrandId { get; set; }
        [Column("brand_name")]
        [StringLength(255)]
        [Unicode(false)]
        public string BrandName { get; set; } = null!;

        [InverseProperty(nameof(Product.Brand))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
