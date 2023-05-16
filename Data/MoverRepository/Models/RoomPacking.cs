using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RoomPacking")]
    public partial class RoomPacking
    {
        [Key]
        public int Id { get; set; }
        public int RequestRoomId { get; set; }
        public int PackageSizeId { get; set; }
        public int? QuantityEstimate { get; set; }
        [Column("PBOActual")]
        public int? Pboactual { get; set; }
        [Column("PBCTActual")]
        public int? Pbctactual { get; set; }
        public double Price { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("PackageSizeId")]
        [InverseProperty("RoomPackings")]
        public virtual PackageSize PackageSize { get; set; } = null!;
        [ForeignKey("RequestRoomId")]
        [InverseProperty("RoomPackings")]
        public virtual RequestRoom RequestRoom { get; set; } = null!;
    }
}
