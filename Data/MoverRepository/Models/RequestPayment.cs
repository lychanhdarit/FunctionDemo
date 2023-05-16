using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestPayment")]
    public partial class RequestPayment
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateReceived { get; set; }
        public int PaymentType { get; set; }
        public double Amount { get; set; }
        [StringLength(1000)]
        public string? Note { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("RequestPayments")]
        public virtual Request Request { get; set; } = null!;
    }
}
