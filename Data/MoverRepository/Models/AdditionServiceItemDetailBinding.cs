using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AdditionServiceItemDetailBinding")]
    public partial class AdditionServiceItemDetailBinding
    {
        [Key]
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        public int AdditionServiceItemId { get; set; }
        public int Value { get; set; }
        public double Price { get; set; }

        [ForeignKey("AdditionServiceItemId")]
        [InverseProperty("AdditionServiceItemDetailBindings")]
        public virtual AdditionServiceItem AdditionServiceItem { get; set; } = null!;
    }
}
