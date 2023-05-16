using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("CustomerFollow")]
    public partial class CustomerFollow
    {
        [Key]
        public int Id { get; set; }
        public int AuctionItemId { get; set; }
        public int CustomerId { get; set; }
        public bool? IsFollowed { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("AuctionItemId")]
        [InverseProperty("CustomerFollows")]
        public virtual AuctionItem AuctionItem { get; set; } = null!;
        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerFollows")]
        public virtual AuctionCustomer Customer { get; set; } = null!;
    }
}
