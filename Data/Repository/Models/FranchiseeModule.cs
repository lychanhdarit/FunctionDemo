using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("Franchisee_Module")]
    public partial class FranchiseeModule
    {
        [Key]
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        public int FranchiseeId { get; set; }
        public int ModuleId { get; set; }

        [ForeignKey("FranchiseeId")]
        [InverseProperty("FranchiseeModules")]
        public virtual FranchiseeTenant Franchisee { get; set; } = null!;
        [ForeignKey("ModuleId")]
        [InverseProperty("FranchiseeModules")]
        public virtual Module Module { get; set; } = null!;
    }
}
