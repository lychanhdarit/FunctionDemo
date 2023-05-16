using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Models
{
    [Table("UserRoleFunction")]
    public partial class UserRoleFunction
    {
        [Key]
        public int Id { get; set; }
        public int UserRoleId { get; set; }
        public int SecurityOperationId { get; set; }
        public int DocumentTypeId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;

        [ForeignKey("DocumentTypeId")]
        [InverseProperty("UserRoleFunctions")]
        public virtual DocumentType DocumentType { get; set; } = null!;
        [ForeignKey("SecurityOperationId")]
        [InverseProperty("UserRoleFunctions")]
        public virtual SecurityOperation SecurityOperation { get; set; } = null!;
        [ForeignKey("UserRoleId")]
        [InverseProperty("UserRoleFunctions")]
        public virtual UserRole UserRole { get; set; } = null!;
    }
}
