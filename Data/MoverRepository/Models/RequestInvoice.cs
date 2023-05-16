using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestInvoice")]
    public partial class RequestInvoice
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public byte[] Data { get; set; } = null!;
        public int? VersionNo { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("RequestInvoices")]
        public virtual Request Request { get; set; } = null!;
    }
}
