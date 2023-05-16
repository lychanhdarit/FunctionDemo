using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("SecurityOperation")]
    [Index("Name", Name = "UK_SecurityOperation_Name", IsUnique = true)]
    public partial class SecurityOperation
    {
        public SecurityOperation()
        {
            UserRoleFunctions = new HashSet<UserRoleFunction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;

        [InverseProperty("SecurityOperation")]
        public virtual ICollection<UserRoleFunction> UserRoleFunctions { get; set; }
    }
}
