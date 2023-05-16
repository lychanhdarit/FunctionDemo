using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("Module")]
    public partial class Module
    {
        public Module()
        {
            FranchiseeModules = new HashSet<FranchiseeModule>();
            ModuleDocumentTypes = new HashSet<ModuleDocumentType>();
        }

        [Key]
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [StringLength(200)]
        public string Name { get; set; } = null!;
        public bool? IsDefault { get; set; }

        [InverseProperty("Module")]
        public virtual ICollection<FranchiseeModule> FranchiseeModules { get; set; }
        [InverseProperty("Module")]
        public virtual ICollection<ModuleDocumentType> ModuleDocumentTypes { get; set; }
    }
}
