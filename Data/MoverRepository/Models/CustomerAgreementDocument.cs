using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("CustomerAgreementDocument")]
    public partial class CustomerAgreementDocument
    {
        public CustomerAgreementDocument()
        {
            SignedAgreementDocuments = new HashSet<SignedAgreementDocument>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? UploadFileId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;

        [ForeignKey("UploadFileId")]
        [InverseProperty("CustomerAgreementDocuments")]
        public virtual UploadFile? UploadFile { get; set; }
        [InverseProperty("CustomerAgreementDocument")]
        public virtual ICollection<SignedAgreementDocument> SignedAgreementDocuments { get; set; }
    }
}
