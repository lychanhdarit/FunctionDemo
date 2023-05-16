using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("AuctionCustomer")]
    public partial class AuctionCustomer
    {
        public AuctionCustomer()
        {
            Bidders = new HashSet<Bidder>();
            CustomerFollows = new HashSet<CustomerFollow>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string? CompanyName { get; set; }
        [StringLength(20)]
        public string? CompanyPhone { get; set; }
        [StringLength(20)]
        public string? Fax { get; set; }
        [StringLength(50)]
        public string? TaxId { get; set; }
        public bool? TaxExempt { get; set; }
        public int? TaxDocumentId { get; set; }
        public int? ConsignmentId { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        public int? BillingLocationId { get; set; }
        public int? ShippingLocationId { get; set; }
        public bool? IsUseBillingLocation { get; set; }
        public bool? IsUseShippingLocation { get; set; }

        [ForeignKey("BillingLocationId")]
        [InverseProperty("AuctionCustomerBillingLocations")]
        public virtual Location? BillingLocation { get; set; }
        [ForeignKey("ConsignmentId")]
        [InverseProperty("AuctionCustomerConsignments")]
        public virtual UploadFile? Consignment { get; set; }
        [ForeignKey("Id")]
        [InverseProperty("AuctionCustomer")]
        public virtual Customer IdNavigation { get; set; } = null!;
        [ForeignKey("ShippingLocationId")]
        [InverseProperty("AuctionCustomerShippingLocations")]
        public virtual Location? ShippingLocation { get; set; }
        [ForeignKey("TaxDocumentId")]
        [InverseProperty("AuctionCustomerTaxDocuments")]
        public virtual UploadFile? TaxDocument { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Bidder> Bidders { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<CustomerFollow> CustomerFollows { get; set; }
    }
}
