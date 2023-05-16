using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("MaxBid")]
    public partial class MaxBid
    {
        [Key]
        public int Id { get; set; }
        public int AuctionItemId { get; set; }
        public int BidderId { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Amount { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("AuctionItemId")]
        [InverseProperty("MaxBids")]
        public virtual AuctionItem AuctionItem { get; set; } = null!;
        [ForeignKey("BidderId")]
        [InverseProperty("MaxBids")]
        public virtual Bidder Bidder { get; set; } = null!;
    }
}
