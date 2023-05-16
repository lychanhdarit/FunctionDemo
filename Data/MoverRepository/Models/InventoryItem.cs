using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("InventoryItem")]
    public partial class InventoryItem
    {
        public InventoryItem()
        {
            AuctionItems = new HashSet<AuctionItem>();
            ConsignmentInvoiceDetails = new HashSet<ConsignmentInvoiceDetail>();
            ItemPhotos = new HashSet<ItemPhoto>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }
        public int? CustomerId { get; set; }
        public int? ZoneId { get; set; }
        public int? StoreId { get; set; }
        public bool? IsDamage { get; set; }
        public int? DamageOfItemId { get; set; }
        public bool? IsDescriptive { get; set; }
        public int? RequestItemDescriptiveId { get; set; }
        public int? NumberOfPiece { get; set; }
        public int? LotNo { get; set; }
        [Column(TypeName = "decimal(15, 2)")]
        public decimal? ReservePrice { get; set; }
        public int Status { get; set; }
        [StringLength(50)]
        public string ItemBarcode { get; set; } = null!;
        public double? Commission { get; set; }
        [StringLength(1000)]
        public string? Note { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("InventoryItems")]
        public virtual Customer? Customer { get; set; }
        [ForeignKey("DamageOfItemId")]
        [InverseProperty("InventoryItems")]
        public virtual DamageOfItem? DamageOfItem { get; set; }
        [ForeignKey("RequestItemDescriptiveId")]
        [InverseProperty("InventoryItems")]
        public virtual RequestItemDescriptive? RequestItemDescriptive { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("InventoryItems")]
        public virtual Store? Store { get; set; }
        [ForeignKey("ZoneId")]
        [InverseProperty("InventoryItems")]
        public virtual Zone? Zone { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<AuctionItem> AuctionItems { get; set; }
        [InverseProperty("InventoryItem")]
        public virtual ICollection<ConsignmentInvoiceDetail> ConsignmentInvoiceDetails { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemPhoto> ItemPhotos { get; set; }
    }
}
