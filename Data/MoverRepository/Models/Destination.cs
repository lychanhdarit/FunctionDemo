using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Destination")]
    public partial class Destination
    {
        public Destination()
        {
            RequestItemRooms = new HashSet<RequestItemRoom>();
        }

        [Key]
        public int Id { get; set; }
        public int? RequestId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string? ContactName { get; set; }
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        [StringLength(1000)]
        public string? Note { get; set; }
        public bool IsConfig { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("Destination")]
        public virtual Location IdNavigation { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("Destinations")]
        public virtual Request? Request { get; set; }
        [InverseProperty("Destination")]
        public virtual ICollection<RequestItemRoom> RequestItemRooms { get; set; }
    }
}
