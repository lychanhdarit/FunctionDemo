using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("DamageOfItem")]
    public partial class DamageOfItem
    {
        public DamageOfItem()
        {
            InventoryItems = new HashSet<InventoryItem>();
            RequestItemRooms = new HashSet<RequestItemRoom>();
        }

        [Key]
        public int Id { get; set; }
        public bool? Field1 { get; set; }
        public bool? Field2 { get; set; }
        public bool? Field3 { get; set; }
        public bool? Field4 { get; set; }
        public bool? Field5 { get; set; }
        public bool? Field6 { get; set; }
        public bool? Field7 { get; set; }
        public bool? Field8 { get; set; }
        public bool? Field9 { get; set; }
        public bool? Field10 { get; set; }
        public bool? Field11 { get; set; }
        public bool? Field12 { get; set; }
        public bool? Field13 { get; set; }
        public bool? Field14 { get; set; }
        public bool? Field15 { get; set; }
        public bool? Field16 { get; set; }
        public bool? Field17 { get; set; }
        public bool? Field18 { get; set; }
        public bool? Field19 { get; set; }
        public bool? Field20 { get; set; }
        public bool? Field21 { get; set; }
        public bool? Field22 { get; set; }
        public bool? Field23 { get; set; }
        public bool? Field24 { get; set; }
        public bool? Field25 { get; set; }
        public bool? Field26 { get; set; }
        public bool? Field27 { get; set; }
        public bool? Field28 { get; set; }
        public bool? Field29 { get; set; }
        public bool? Field30 { get; set; }
        public bool? Field31 { get; set; }
        public bool? Field32 { get; set; }
        public bool? Field33 { get; set; }
        public bool? Field34 { get; set; }
        public bool? Field35 { get; set; }
        public bool? Field36 { get; set; }
        public bool? Field37 { get; set; }
        public bool? Field38 { get; set; }
        public bool? Field39 { get; set; }
        public bool? Field40 { get; set; }
        public bool? Field41 { get; set; }
        public bool? Field42 { get; set; }
        public bool? Field43 { get; set; }
        public bool? Field44 { get; set; }
        public bool? Field45 { get; set; }
        public bool? Field46 { get; set; }
        public bool? Field47 { get; set; }
        public bool? Field48 { get; set; }
        public bool? Field49 { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("DamageOfItem")]
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        [InverseProperty("DamageOfItem")]
        public virtual ICollection<RequestItemRoom> RequestItemRooms { get; set; }
    }
}
