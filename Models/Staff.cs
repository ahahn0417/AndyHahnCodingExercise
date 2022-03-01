using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AndyHahnCodingExercise.Models
{
    [Table("staffs", Schema = "sales")]
    [Index(nameof(Email), Name = "UQ__staffs__AB6E6164CC1C845D", IsUnique = true)]
    public partial class Staff
    {
        public Staff()
        {
            InverseManager = new HashSet<Staff>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [Column("last_name")]
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [Column("email")]
        [StringLength(255)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [Column("phone")]
        [StringLength(25)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [Column("active")]
        public byte Active { get; set; }
        [Column("store_id")]
        public int StoreId { get; set; }
        [Column("manager_id")]
        public int? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Staff.InverseManager))]
        public virtual Staff? Manager { get; set; }
        [ForeignKey(nameof(StoreId))]
        [InverseProperty("staff")]
        public virtual Store Store { get; set; } = null!;
        [InverseProperty(nameof(Staff.Manager))]
        public virtual ICollection<Staff> InverseManager { get; set; }
        [InverseProperty(nameof(Order.Staff))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
