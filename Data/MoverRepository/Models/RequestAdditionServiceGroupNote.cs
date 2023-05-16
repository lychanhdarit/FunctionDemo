using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestAdditionServiceGroupNote")]
    public partial class RequestAdditionServiceGroupNote
    {
        [Key]
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public int AdditionServiceTypeId { get; set; }
        public int RequestId { get; set; }
        [StringLength(500)]
        public string Note { get; set; } = null!;

        [ForeignKey("AdditionServiceTypeId")]
        [InverseProperty("RequestAdditionServiceGroupNotes")]
        public virtual AdditionServiceType AdditionServiceType { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("RequestAdditionServiceGroupNotes")]
        public virtual Request Request { get; set; } = null!;
    }
}
