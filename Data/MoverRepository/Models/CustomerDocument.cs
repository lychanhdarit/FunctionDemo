using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("CustomerDocument")]
    public partial class CustomerDocument
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [StringLength(200)]
        public string DocumentName { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerDocuments")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey("Id")]
        [InverseProperty("CustomerDocument")]
        public virtual UploadFile IdNavigation { get; set; } = null!;
    }
}
