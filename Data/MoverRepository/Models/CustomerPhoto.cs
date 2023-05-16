using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("CustomerPhoto")]
    public partial class CustomerPhoto
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerPhotos")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey("Id")]
        [InverseProperty("CustomerPhoto")]
        public virtual UploadFile IdNavigation { get; set; } = null!;
    }
}
