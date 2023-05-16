using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("GridConfig")]
    [Index("DocumentTypeId", "GridInternalName", "UserId", Name = "UK_GridConfig_FunctionId_UserId", IsUnique = true)]
    public partial class GridConfig
    {
        [Key]
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "xml")]
        public string XmlText { get; set; } = null!;
        [StringLength(255)]
        public string GridInternalName { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;

        [ForeignKey("DocumentTypeId")]
        [InverseProperty("GridConfigs")]
        public virtual DocumentType DocumentType { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("GridConfigs")]
        public virtual User User { get; set; } = null!;
    }
}
