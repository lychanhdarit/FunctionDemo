using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("Module_DocumentType")]
    public partial class ModuleDocumentType
    {
        [Key]
        public int Id { get; set; }
        public byte[] LastModified { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public int DocumentTypeId { get; set; }
        public int ModuleId { get; set; }

        [ForeignKey("DocumentTypeId")]
        [InverseProperty("ModuleDocumentTypes")]
        public virtual DocumentType DocumentType { get; set; } = null!;
        [ForeignKey("ModuleId")]
        [InverseProperty("ModuleDocumentTypes")]
        public virtual Module Module { get; set; } = null!;
    }
}
