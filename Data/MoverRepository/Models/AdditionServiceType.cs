using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AdditionServiceType")]
    public partial class AdditionServiceType
    {
        public AdditionServiceType()
        {
            AdditionServiceItems = new HashSet<AdditionServiceItem>();
            RequestAdditionServiceGroupNotes = new HashSet<RequestAdditionServiceGroupNote>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        public int OrderNo { get; set; }
        public bool IsApplyTax { get; set; }
        public bool? IsShowDetail { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("AdditionServiceType")]
        public virtual ICollection<AdditionServiceItem> AdditionServiceItems { get; set; }
        [InverseProperty("AdditionServiceType")]
        public virtual ICollection<RequestAdditionServiceGroupNote> RequestAdditionServiceGroupNotes { get; set; }
    }
}
