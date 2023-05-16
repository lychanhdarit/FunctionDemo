using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RoomItem")]
    public partial class RoomItem
    {
        public RoomItem()
        {
            RequestItemRooms = new HashSet<RequestItemRoom>();
        }

        [Key]
        public int Id { get; set; }
        public int? RoomId { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public int CubeValue { get; set; }
        public bool? IsDefault { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("RoomId")]
        [InverseProperty("RoomItems")]
        public virtual Room? Room { get; set; }
        [InverseProperty("RoomItem")]
        public virtual ICollection<RequestItemRoom> RequestItemRooms { get; set; }
    }
}
