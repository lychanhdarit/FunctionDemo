using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("MoveContact")]
    public partial class MoveContact
    {
        public MoveContact()
        {
            MovingCustomers = new HashSet<MovingCustomer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(20)]
        public string PrimaryPhone { get; set; } = null!;
        public int? PrimaryPhoneType { get; set; }
        [StringLength(20)]
        public string? SecondaryPhone { get; set; }
        public int? SecondaryPhoneType { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("MoveContact")]
        public virtual ICollection<MovingCustomer> MovingCustomers { get; set; }
    }
}
