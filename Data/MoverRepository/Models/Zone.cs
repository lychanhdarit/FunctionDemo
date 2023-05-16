using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Zone")]
    public partial class Zone
    {
        public Zone()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        public string? ZoneNo { get; set; }
        public string? Description { get; set; }
        public int? Type { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public bool? IsDefault { get; set; }

        [InverseProperty("Zone")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
