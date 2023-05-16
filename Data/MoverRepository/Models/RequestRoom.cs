using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestRoom")]
    public partial class RequestRoom
    {
        public RequestRoom()
        {
            RequestItemRooms = new HashSet<RequestItemRoom>();
            RoomPackings = new HashSet<RoomPacking>();
        }

        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int RequestId { get; set; }
        public double? PackingEstimateTime { get; set; }
        public double? MovingEstimateTime { get; set; }
        public double? PackingActualTime { get; set; }
        public double? MovingActualTime { get; set; }
        [StringLength(1000)]
        public string? Note { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("RequestRooms")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("RoomId")]
        [InverseProperty("RequestRooms")]
        public virtual Room Room { get; set; } = null!;
        [InverseProperty("RequestRoom")]
        public virtual ICollection<RequestItemRoom> RequestItemRooms { get; set; }
        [InverseProperty("RequestRoom")]
        public virtual ICollection<RoomPacking> RoomPackings { get; set; }
    }
}
