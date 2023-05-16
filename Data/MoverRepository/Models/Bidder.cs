using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Bidder")]
    public partial class Bidder
    {
        public Bidder()
        {
            Bids = new HashSet<Bid>();
            Invoices = new HashSet<Invoice>();
            MaxBids = new HashSet<MaxBid>();
        }

        [Key]
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public int CustomerId { get; set; }
        public int BidderNo { get; set; }
        public int? CheckInType { get; set; }
        public bool? IsCheckIn { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("AuctionId")]
        [InverseProperty("Bidders")]
        public virtual Auction Auction { get; set; } = null!;
        [ForeignKey("CustomerId")]
        [InverseProperty("Bidders")]
        public virtual AuctionCustomer Customer { get; set; } = null!;
        [InverseProperty("Bidder")]
        public virtual ICollection<Bid> Bids { get; set; }
        [InverseProperty("Bidder")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [InverseProperty("Bidder")]
        public virtual ICollection<MaxBid> MaxBids { get; set; }
    }
}
