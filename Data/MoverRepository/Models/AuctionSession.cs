using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AuctionSession")]
    public partial class AuctionSession
    {
        [Key]
        public int Id { get; set; }
        public int AuctionId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? From { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? To { get; set; }
        public int Type { get; set; }
        public int OrderNo { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("AuctionId")]
        [InverseProperty("AuctionSessions")]
        public virtual Auction Auction { get; set; } = null!;
    }
}
