using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("SignedAgreementDocument")]
    public partial class SignedAgreementDocument
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int CustomerAgreementDocumentId { get; set; }
        public int? UploadFileId { get; set; }
        public byte[] Signature { get; set; } = null!;
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [ForeignKey("CustomerAgreementDocumentId")]
        [InverseProperty("SignedAgreementDocuments")]
        public virtual CustomerAgreementDocument CustomerAgreementDocument { get; set; } = null!;
        [ForeignKey("RequestId")]
        [InverseProperty("SignedAgreementDocuments")]
        public virtual Request Request { get; set; } = null!;
        [ForeignKey("UploadFileId")]
        [InverseProperty("SignedAgreementDocuments")]
        public virtual UploadFile? UploadFile { get; set; }
    }
}
