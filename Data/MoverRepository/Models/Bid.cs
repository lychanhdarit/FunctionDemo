using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Bid")]
    public partial class Bid
    {
        public Bid()
        {
            AuctionItemSolds = new HashSet<AuctionItemSold>();
        }

        [Key]
        public int Id { get; set; }
        public int BidderId { get; set; }
        public int AuctionItemId { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BidDate { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("AuctionItemId")]
        [InverseProperty("Bids")]
        public virtual AuctionItem AuctionItem { get; set; } = null!;
        [ForeignKey("BidderId")]
        [InverseProperty("Bids")]
        public virtual Bidder Bidder { get; set; } = null!;
        [InverseProperty("Bid")]
        public virtual ICollection<AuctionItemSold> AuctionItemSolds { get; set; }
    }
}
