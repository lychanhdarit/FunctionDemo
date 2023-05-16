using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("MovingCustomer")]
    public partial class MovingCustomer
    {
        public MovingCustomer()
        {
            Requests = new HashSet<Request>();
        }

        [Key]
        public int Id { get; set; }
        public int? MoveContactId { get; set; }
        public bool? IsUsePrimaryContact { get; set; }
        [StringLength(100)]
        public string? PrimaryContactName { get; set; }
        public int? RelationToContact { get; set; }
        [StringLength(20)]
        public string? ContactPhoneNumber { get; set; }
        [StringLength(20)]
        public string? ReferredBy { get; set; }
        [Column("EmailCC")]
        [StringLength(100)]
        public string? EmailCc { get; set; }
        [StringLength(20)]
        public string? Emergency { get; set; }
        public bool? IsPet { get; set; }
        public bool? IsHandicap { get; set; }
        public bool? IsUseMoveContact { get; set; }
        public bool? IsActived { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("MovingCustomer")]
        public virtual Customer IdNavigation { get; set; } = null!;
        [ForeignKey("MoveContactId")]
        [InverseProperty("MovingCustomers")]
        public virtual MoveContact? MoveContact { get; set; }
        [InverseProperty("MovingCustomer")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}
