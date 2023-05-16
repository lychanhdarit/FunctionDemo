using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("FranchiseeTenant")]
    [Index("Name", Name = "UK_CuongTest_Name", IsUnique = true)]
    public partial class FranchiseeTenant
    {
        public FranchiseeTenant()
        {
            FranchiseeModules = new HashSet<FranchiseeModule>();
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
        [StringLength(50)]
        public string Server { get; set; } = null!;
        [StringLength(50)]
        public string Database { get; set; } = null!;
        [StringLength(200)]
        public string Password { get; set; } = null!;
        [StringLength(50)]
        public string UserName { get; set; } = null!;
        [StringLength(200)]
        public string Address1 { get; set; } = null!;
        [StringLength(20)]
        public string OfficePhone { get; set; } = null!;
        [StringLength(200)]
        public string? Address2 { get; set; }
        [StringLength(20)]
        public string? FaxNumber { get; set; }
        [StringLength(25)]
        public string City { get; set; } = null!;
        [StringLength(5)]
        public string Zip { get; set; } = null!;
        [StringLength(50)]
        public string State { get; set; } = null!;
        [StringLength(200)]
        public string? LicenseKey { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartActiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndActiveDate { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("Franchisee")]
        public virtual ICollection<FranchiseeModule> FranchiseeModules { get; set; }
    }
}
