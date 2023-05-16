using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestPacking")]
    public partial class RequestPacking
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int PackageSizeId { get; set; }
        public int? EstimateValue { get; set; }
        public int? ActualValue { get; set; }
        public double Price { get; set; }
        public int? EstimateEditValue { get; set; }
        public int? ActualEditValue { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("PackageSizeId")]
        [InverseProperty("RequestPackings")]
        public virtual PackageSize PackageSize { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("RequestPackings")]
        public virtual Request Request { get; set; } = null!;
    }
}
