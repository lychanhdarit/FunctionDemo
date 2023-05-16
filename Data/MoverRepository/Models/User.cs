using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("User")]
    [Index("UserName", Name = "UK_User_UserName", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            GridConfigs = new HashSet<GridConfig>();
            Requests = new HashSet<Request>();
            StoreAssociateUsers = new HashSet<StoreAssociateUser>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string UserName { get; set; } = null!;
        [StringLength(100)]
        public string Password { get; set; } = null!;
        public int UserRoleId { get; set; }
        public bool IsActive { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string? MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        public int LocationId { get; set; }
        [StringLength(20)]
        public string PrimaryPhone { get; set; } = null!;
        public int PrimaryPhoneType { get; set; }
        [StringLength(20)]
        public string? SecondaryPhone { get; set; }
        public int? SecondaryPhoneType { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [Column(TypeName = "image")]
        public byte[]? Avatar { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        public bool? IsHarmonyUser { get; set; }
        public int? UserType { get; set; }
        public bool? IsNoEmail { get; set; }
        public bool? IsFirstLogin { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string? GroupKeySearch { get; set; }

        [ForeignKey("LocationId")]
        [InverseProperty("Users")]
        public virtual Location Location { get; set; } = null!;
        [ForeignKey("UserRoleId")]
        [InverseProperty("Users")]
        public virtual UserRole UserRole { get; set; } = null!;
        [InverseProperty("IdNavigation")]
        public virtual Customer? Customer { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<GridConfig> GridConfigs { get; set; }
        [InverseProperty("AssignTo")]
        public virtual ICollection<Request> Requests { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<StoreAssociateUser> StoreAssociateUsers { get; set; }
    }
}
