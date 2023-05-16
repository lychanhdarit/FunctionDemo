using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("MovingItem")]
    public partial class MovingItem
    {
        [Key]
        public int Id { get; set; }
        public int RequestItemRoomId { get; set; }
        [StringLength(50)]
        public string ItemBarcode { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public int? Status { get; set; }
        [StringLength(500)]
        public string? LoadedPiece { get; set; }
        [StringLength(500)]
        public string? UnloadedPiece { get; set; }

        [ForeignKey("RequestItemRoomId")]
        [InverseProperty("MovingItems")]
        public virtual RequestItemRoom RequestItemRoom { get; set; } = null!;
    }
}
