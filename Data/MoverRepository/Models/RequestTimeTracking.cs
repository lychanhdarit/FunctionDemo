using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("RequestTimeTracking")]
    public partial class RequestTimeTracking
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int HelperId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TrackingDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BreakStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BreakEnd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LunchStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LunchEnd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SecondBreakStart { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SecondBreakEnd { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndTime { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("HelperId")]
        [InverseProperty("RequestTimeTrackings")]
        public virtual Helper Helper { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("RequestTimeTrackings")]
        public virtual Request Request { get; set; } = null!;
    }
}
