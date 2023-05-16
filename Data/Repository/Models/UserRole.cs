using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("UserRole")]
    [Index("Name", Name = "UK_UserRole_Name", IsUnique = true)]
    public partial class UserRole
    {
        public UserRole()
        {
            UserRoleFunctions = new HashSet<UserRoleFunction>();
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [StringLength(50)]
        public string? AppRoleName { get; set; }
        public bool? IsSystem { get; set; }
        public bool? IsDefault { get; set; }

        [InverseProperty("UserRole")]
        public virtual ICollection<UserRoleFunction> UserRoleFunctions { get; set; }
        [InverseProperty("UserRole")]
        public virtual ICollection<User> Users { get; set; }
    }
}
