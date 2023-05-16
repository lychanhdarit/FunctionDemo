using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("FranchiseeConfig")]
    public partial class FranchiseeConfig
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string FranchiseeContact { get; set; } = null!;
        [StringLength(20)]
        public string PrimaryContactPhone { get; set; } = null!;
        [StringLength(50)]
        public string? PrimaryContactEmail { get; set; }
        [StringLength(20)]
        public string? PrimaryContactFax { get; set; }
        [StringLength(20)]
        public string? PrimaryContactCellNumber { get; set; }
        [StringLength(25)]
        public string City { get; set; } = null!;
        [StringLength(50)]
        public string State { get; set; } = null!;
        [StringLength(5)]
        public string Zip { get; set; } = null!;
        [StringLength(25)]
        public string Address1 { get; set; } = null!;
        [StringLength(25)]
        public string? Address2 { get; set; }
        [StringLength(20)]
        public string OfficePhone { get; set; } = null!;
        [StringLength(20)]
        public string FaxNumber { get; set; } = null!;
        [Column(TypeName = "image")]
        public byte[]? Logo { get; set; }
        [StringLength(200)]
        public string? FranchiseeId { get; set; }
        [StringLength(200)]
        public string LicenseKey { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [StringLength(50)]
        public string Name { get; set; } = null!;
    }
}
