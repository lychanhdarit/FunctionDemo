﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestPhoto")]
    public partial class RequestPhoto
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("RequestPhoto")]
        public virtual UploadFile IdNavigation { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("RequestPhotos")]
        public virtual Request Request { get; set; } = null!;
    }
}
