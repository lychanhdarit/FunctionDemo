using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("CustomerItemCode")]
    public partial class CustomerItemCode
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string CustomerCode { get; set; } = null!;
        public int? CurrentItemNo { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public int? ReqNumber { get; set; }
    }
}
