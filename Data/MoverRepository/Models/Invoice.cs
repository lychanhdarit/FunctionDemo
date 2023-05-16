using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        public Invoice()
        {
            AuctionItemSolds = new HashSet<AuctionItemSold>();
        }

        [Key]
        public int Id { get; set; }
        public int BidderId { get; set; }
        public int? PaymentType { get; set; }
        [StringLength(50)]
        public string? CheckNumber { get; set; }
        public int? InvoiceType { get; set; }
        [StringLength(50)]
        public string? InvoiceNumber { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("BidderId")]
        [InverseProperty("Invoices")]
        public virtual Bidder Bidder { get; set; } = null!;
        [InverseProperty("Invoice")]
        public virtual ICollection<AuctionItemSold> AuctionItemSolds { get; set; }
    }
}
