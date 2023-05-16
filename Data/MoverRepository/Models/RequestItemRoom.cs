using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestItemRoom")]
    public partial class RequestItemRoom
    {
        public RequestItemRoom()
        {
            MovingItems = new HashSet<MovingItem>();
            RequestItemPhotos = new HashSet<RequestItemPhoto>();
        }

        [Key]
        public int Id { get; set; }
        public int RequestRoomId { get; set; }
        public int RoomItemId { get; set; }
        public int DestinationId { get; set; }
        public int Quantity { get; set; }
        public int? NumberOfPiece { get; set; }
        public bool? IsDamage { get; set; }
        public bool? IsVerify { get; set; }
        public bool? IsDescriptive { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public int? DamageOfItemId { get; set; }
        public int? RequestItemDescriptiveId { get; set; }

        [ForeignKey("DamageOfItemId")]
        [InverseProperty("RequestItemRooms")]
        public virtual DamageOfItem? DamageOfItem { get; set; }
        [ForeignKey("DestinationId")]
        [InverseProperty("RequestItemRooms")]
        public virtual Destination Destination { get; set; } = null!;
        [ForeignKey("RequestItemDescriptiveId")]
        [InverseProperty("RequestItemRooms")]
        public virtual RequestItemDescriptive? RequestItemDescriptive { get; set; }
        [ForeignKey("RequestRoomId")]
        [InverseProperty("RequestItemRooms")]
        public virtual RequestRoom RequestRoom { get; set; } = null!;
        [ForeignKey("RoomItemId")]
        [InverseProperty("RequestItemRooms")]
        public virtual RoomItem RoomItem { get; set; } = null!;
        [InverseProperty("RequestItemRoom")]
        public virtual ICollection<MovingItem> MovingItems { get; set; }
        [InverseProperty("RequestItemRoom")]
        public virtual ICollection<RequestItemPhoto> RequestItemPhotos { get; set; }
    }
}
