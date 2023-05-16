using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("UploadFile")]
    public partial class UploadFile
    {
        public UploadFile()
        {
            AuctionCustomerConsignments = new HashSet<AuctionCustomer>();
            AuctionCustomerTaxDocuments = new HashSet<AuctionCustomer>();
            CustomerAgreementDocuments = new HashSet<CustomerAgreementDocument>();
            SignedAgreementDocuments = new HashSet<SignedAgreementDocument>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(360)]
        public string FileName { get; set; } = null!;
        public int FileSize { get; set; }
        [StringLength(500)]
        public string? FilePath { get; set; }
        public Guid? GuidId { get; set; }
        public bool? IsNeedServiceDelete { get; set; }
        public bool? IsCopyToImageServer { get; set; }
        public int FileType { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual CustomerDocument? CustomerDocument { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual CustomerPhoto? CustomerPhoto { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual ItemPhoto? ItemPhoto { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual RequestItemPhoto? RequestItemPhoto { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual RequestPhoto? RequestPhoto { get; set; }
        [InverseProperty("Consignment")]
        public virtual ICollection<AuctionCustomer> AuctionCustomerConsignments { get; set; }
        [InverseProperty("TaxDocument")]
        public virtual ICollection<AuctionCustomer> AuctionCustomerTaxDocuments { get; set; }
        [InverseProperty("UploadFile")]
        public virtual ICollection<CustomerAgreementDocument> CustomerAgreementDocuments { get; set; }
        [InverseProperty("UploadFile")]
        public virtual ICollection<SignedAgreementDocument> SignedAgreementDocuments { get; set; }
    }
}
