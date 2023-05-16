using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("ConsignmentInvoiceDetail")]
    public partial class ConsignmentInvoiceDetail
    {
        [Key]
        public int Id { get; set; }
        public int ConsignmentInvoiceId { get; set; }
        public int InventoryItemId { get; set; }
        public double Price { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("ConsignmentInvoiceId")]
        [InverseProperty("ConsignmentInvoiceDetails")]
        public virtual ConsignmentInvoice ConsignmentInvoice { get; set; } = null!;
        [ForeignKey("InventoryItemId")]
        [InverseProperty("ConsignmentInvoiceDetails")]
        public virtual InventoryItem InventoryItem { get; set; } = null!;
    }
}
