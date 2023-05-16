using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerDocuments = new HashSet<CustomerDocument>();
            CustomerNotes = new HashSet<CustomerNote>();
            CustomerPhotos = new HashSet<CustomerPhoto>();
            InventoryItems = new HashSet<InventoryItem>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string CustomerCode { get; set; } = null!;
        public int? Title { get; set; }
        public int? EditingType { get; set; }
        public int? EditingUserId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public bool? IsCreatedBidder { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("Customer")]
        public virtual User IdNavigation { get; set; } = null!;
        [InverseProperty("IdNavigation")]
        public virtual AuctionCustomer? AuctionCustomer { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual MovingCustomer? MovingCustomer { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerDocument> CustomerDocuments { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerNote> CustomerNotes { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerPhoto> CustomerPhotos { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
