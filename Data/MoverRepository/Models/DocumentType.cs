using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("DocumentType")]
    public partial class DocumentType
    {
        public DocumentType()
        {
            GridConfigs = new HashSet<GridConfig>();
            UserRoleFunctions = new HashSet<UserRoleFunction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
        [StringLength(1000)]
        public string Title { get; set; } = null!;
        public int Order { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [StringLength(50)]
        public string? Type { get; set; }
        public int DocType { get; set; }

        [InverseProperty("DocumentType")]
        public virtual ICollection<GridConfig> GridConfigs { get; set; }
        [InverseProperty("DocumentType")]
        public virtual ICollection<UserRoleFunction> UserRoleFunctions { get; set; }
    }
}
