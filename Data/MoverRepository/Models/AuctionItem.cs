using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AuctionItem")]
    public partial class AuctionItem
    {
        public AuctionItem()
        {
            Bids = new HashSet<Bid>();
            CustomerFollows = new HashSet<CustomerFollow>();
            MaxBids = new HashSet<MaxBid>();
        }

        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int AuctionId { get; set; }
        [StringLength(20)]
        public string? AuctionItemCode { get; set; }
        public int LotNo { get; set; }
        public bool? IsFeatured { get; set; }
        public int? Status { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("AuctionId")]
        [InverseProperty("AuctionItems")]
        public virtual Auction Auction { get; set; } = null!;
        [ForeignKey("ItemId")]
        [InverseProperty("AuctionItems")]
        public virtual InventoryItem Item { get; set; } = null!;
        [InverseProperty("IdNavigation")]
        public virtual AuctionItemSold? AuctionItemSold { get; set; }
        [InverseProperty("AuctionItem")]
        public virtual ICollection<Bid> Bids { get; set; }
        [InverseProperty("AuctionItem")]
        public virtual ICollection<CustomerFollow> CustomerFollows { get; set; }
        [InverseProperty("AuctionItem")]
        public virtual ICollection<MaxBid> MaxBids { get; set; }
    }
}
