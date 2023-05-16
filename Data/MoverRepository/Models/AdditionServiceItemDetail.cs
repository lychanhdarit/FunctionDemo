using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AdditionServiceItemDetail")]
    public partial class AdditionServiceItemDetail
    {
        public AdditionServiceItemDetail()
        {
            RequestAdditionServices = new HashSet<RequestAdditionService>();
        }

        [Key]
        public int Id { get; set; }
        public int AdditionServiceItemId { get; set; }
        [StringLength(1000)]
        public string Title { get; set; } = null!;
        [StringLength(100)]
        public string? Unit { get; set; }
        [StringLength(100)]
        public string? Icon { get; set; }
        public double? DefaultValue { get; set; }
        public double? AdditionRate { get; set; }
        public bool? IsCost { get; set; }
        public int? OrderNo { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [StringLength(100)]
        public string? DisplayName { get; set; }
        public int? NumberDecimal { get; set; }
        public int? BindingType { get; set; }
        /// <summary>
        /// 1. Room Paking Time, 2. Room Moving Time
        /// </summary>
        public int? AutoChangeType { get; set; }

        [ForeignKey("AdditionServiceItemId")]
        [InverseProperty("AdditionServiceItemDetails")]
        public virtual AdditionServiceItem AdditionServiceItem { get; set; } = null!;
        [InverseProperty("AdditionServiceItemDetail")]
        public virtual ICollection<RequestAdditionService> RequestAdditionServices { get; set; }
    }
}
