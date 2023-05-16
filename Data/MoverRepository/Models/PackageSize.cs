using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("PackageSize")]
    public partial class PackageSize
    {
        public PackageSize()
        {
            RequestPackings = new HashSet<RequestPacking>();
            RoomPackings = new HashSet<RoomPacking>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string SizeName { get; set; } = null!;
        public double ReferencePrice { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("PackageSize")]
        public virtual ICollection<RequestPacking> RequestPackings { get; set; }
        [InverseProperty("PackageSize")]
        public virtual ICollection<RoomPacking> RoomPackings { get; set; }
    }
}
