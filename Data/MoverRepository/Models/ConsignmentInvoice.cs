using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("ConsignmentInvoice")]
    public partial class ConsignmentInvoice
    {
        public ConsignmentInvoice()
        {
            ConsignmentInvoiceDetails = new HashSet<ConsignmentInvoiceDetail>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? InvoiceNo { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; } = null!;
        [StringLength(20)]
        public string? Phone { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        public double? TaxValue { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("ConsignmentInvoice")]
        public virtual ICollection<ConsignmentInvoiceDetail> ConsignmentInvoiceDetails { get; set; }
    }
}
