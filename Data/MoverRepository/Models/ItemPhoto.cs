using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("ItemPhoto")]
    public partial class ItemPhoto
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("ItemPhoto")]
        public virtual UploadFile IdNavigation { get; set; } = null!;
        [ForeignKey("ItemId")]
        [InverseProperty("ItemPhotos")]
        public virtual InventoryItem Item { get; set; } = null!;
    }
}
