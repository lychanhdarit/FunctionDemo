using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AdditionServiceItem")]
    public partial class AdditionServiceItem
    {
        public AdditionServiceItem()
        {
            AdditionServiceItemDetailBindings = new HashSet<AdditionServiceItemDetailBinding>();
            AdditionServiceItemDetails = new HashSet<AdditionServiceItemDetail>();
        }

        [Key]
        public int Id { get; set; }
        public int AdditionServiceTypeId { get; set; }
        public int OrderNo { get; set; }
        [StringLength(7)]
        public string? BackgroundColor { get; set; }
        public bool? IsApplyTax { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [StringLength(200)]
        public string? Name { get; set; }
        public double? TaxValue { get; set; }

        [ForeignKey("AdditionServiceTypeId")]
        [InverseProperty("AdditionServiceItems")]
        public virtual AdditionServiceType AdditionServiceType { get; set; } = null!;
        [InverseProperty("AdditionServiceItem")]
        public virtual ICollection<AdditionServiceItemDetailBinding> AdditionServiceItemDetailBindings { get; set; }
        [InverseProperty("AdditionServiceItem")]
        public virtual ICollection<AdditionServiceItemDetail> AdditionServiceItemDetails { get; set; }
    }
}
