using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Room")]
    public partial class Room
    {
        public Room()
        {
            RequestRooms = new HashSet<RequestRoom>();
            RoomItems = new HashSet<RoomItem>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("Room")]
        public virtual ICollection<RequestRoom> RequestRooms { get; set; }
        [InverseProperty("Room")]
        public virtual ICollection<RoomItem> RoomItems { get; set; }
    }
}
