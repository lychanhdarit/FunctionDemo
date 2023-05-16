using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestItemPhoto")]
    public partial class RequestItemPhoto
    {
        [Key]
        public int Id { get; set; }
        public int RequestItemRoomId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("RequestItemPhoto")]
        public virtual UploadFile IdNavigation { get; set; } = null!;
        [ForeignKey("RequestItemRoomId")]
        [InverseProperty("RequestItemPhotos")]
        public virtual RequestItemRoom RequestItemRoom { get; set; } = null!;
    }
}
