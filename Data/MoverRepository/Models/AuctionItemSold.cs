using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AuctionItemSold")]
    public partial class AuctionItemSold
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int? BidId { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Price { get; set; }
        public int SellType { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("BidId")]
        [InverseProperty("AuctionItemSolds")]
        public virtual Bid? Bid { get; set; }
        [ForeignKey("Id")]
        [InverseProperty("AuctionItemSold")]
        public virtual AuctionItem IdNavigation { get; set; } = null!;
        [ForeignKey("InvoiceId")]
        [InverseProperty("AuctionItemSolds")]
        public virtual Invoice Invoice { get; set; } = null!;
    }
}
