using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Store")]
    public partial class Store
    {
        public Store()
        {
            Auctions = new HashSet<Auction>();
            InventoryItems = new HashSet<InventoryItem>();
            StoreAssociateUsers = new HashSet<StoreAssociateUser>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        public int LocationId { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(20)]
        public string? Fax { get; set; }
        [StringLength(20)]
        public string? OfficePhone { get; set; }
        [StringLength(200)]
        public string? DefaultActivationEmail { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("Stores")]
        public virtual Location Location { get; set; } = null!;
        [InverseProperty("Store")]
        public virtual ICollection<Auction> Auctions { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        [InverseProperty("Store")]
        public virtual ICollection<StoreAssociateUser> StoreAssociateUsers { get; set; }
    }
}
