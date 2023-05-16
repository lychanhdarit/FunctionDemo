using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestAdditionService")]
    public partial class RequestAdditionService
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int AdditionServiceItemDetailId { get; set; }
        public double? EstimateValue { get; set; }
        public double? ActualValue { get; set; }
        public double? TaxValue { get; set; }
        public bool? IsInvoice { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public bool? IsEditedEstimate { get; set; }
        public bool? IsEditedActual { get; set; }

        [ForeignKey("AdditionServiceItemDetailId")]
        [InverseProperty("RequestAdditionServices")]
        public virtual AdditionServiceItemDetail AdditionServiceItemDetail { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("RequestAdditionServices")]
        public virtual Request Request { get; set; } = null!;
    }
}
