using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Auction")]
    public partial class Auction
    {
        public Auction()
        {
            AuctionItems = new HashSet<AuctionItem>();
            AuctionSessions = new HashSet<AuctionSession>();
            Bidders = new HashSet<Bidder>();
        }

        [Key]
        public int Id { get; set; }
        public int StoreId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        public double? TaxRate { get; set; }
        public int? Status { get; set; }
        public int? CurrentLotNo { get; set; }
        public bool? IsChangeStatus { get; set; }
        public bool? IsChangeEndDate { get; set; }
        public bool? IsChangeStartDate { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public bool? IsPaused { get; set; }

        [ForeignKey("StoreId")]
        [InverseProperty("Auctions")]
        public virtual Store Store { get; set; } = null!;
        [InverseProperty("Auction")]
        public virtual ICollection<AuctionItem> AuctionItems { get; set; }
        [InverseProperty("Auction")]
        public virtual ICollection<AuctionSession> AuctionSessions { get; set; }
        [InverseProperty("Auction")]
        public virtual ICollection<Bidder> Bidders { get; set; }
    }
}
