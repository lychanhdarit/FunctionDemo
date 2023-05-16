using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("StoreAssociateUser")]
    public partial class StoreAssociateUser
    {
        [Key]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("StoreId")]
        [InverseProperty("StoreAssociateUsers")]
        public virtual Store Store { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("StoreAssociateUsers")]
        public virtual User User { get; set; } = null!;
    }
}
