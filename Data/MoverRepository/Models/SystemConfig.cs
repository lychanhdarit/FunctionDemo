using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        [StringLength(1000)]
        public string Value { get; set; } = null!;
        [StringLength(20)]
        public string DataType { get; set; } = null!;
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public byte[] LastModified { get; set; } = null!;
        public int? NameType { get; set; }
    }
}
