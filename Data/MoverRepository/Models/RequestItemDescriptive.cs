using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestItemDescriptive")]
    public partial class RequestItemDescriptive
    {
        public RequestItemDescriptive()
        {
            InventoryItems = new HashSet<InventoryItem>();
            RequestItemRooms = new HashSet<RequestItemRoom>();
        }

        [Key]
        public int Id { get; set; }
        public bool? Field19 { get; set; }
        public bool? Field18 { get; set; }
        public bool? Field17 { get; set; }
        public bool? Field16 { get; set; }
        public bool? Field15 { get; set; }
        public bool? Field14 { get; set; }
        public bool? Field13 { get; set; }
        public bool? Field12 { get; set; }
        public bool? Field11 { get; set; }
        public bool? Field10 { get; set; }
        public bool? Field9 { get; set; }
        public bool? Field8 { get; set; }
        public bool? Field7 { get; set; }
        public bool? Field6 { get; set; }
        public bool? Field5 { get; set; }
        public bool? Field4 { get; set; }
        public bool? Field3 { get; set; }
        public bool? Field2 { get; set; }
        public bool? Field1 { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("RequestItemDescriptive")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        [InverseProperty("RequestItemDescriptive")]
        public virtual ICollection<RequestItemRoom> RequestItemRooms { get; set; }
    }
}
