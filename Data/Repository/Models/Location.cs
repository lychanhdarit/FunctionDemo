using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("Location")]
    public partial class Location
    {
        public Location()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [StringLength(100)]
        public string Address1 { get; set; } = null!;
        [StringLength(100)]
        public string? Address2 { get; set; }
        [StringLength(50)]
        public string City { get; set; } = null!;
        [StringLength(20)]
        public string Zip { get; set; } = null!;
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("StateId")]
        [InverseProperty("Locations")]
        public virtual State State { get; set; } = null!;
        [InverseProperty("Location")]
        public virtual ICollection<User> Users { get; set; }
    }
}
