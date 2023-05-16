using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("State")]
    public partial class State
    {
        public State()
        {
            Locations = new HashSet<Location>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [StringLength(5)]
        public string? AbbreviationName { get; set; }

        [InverseProperty("State")]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
