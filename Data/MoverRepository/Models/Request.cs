using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.MoverRepository.Models
{
    [Table("Request")]
    public partial class Request
    {
        public Request()
        {
            Destinations = new HashSet<Destination>();
            RequestAdditionServiceGroupNotes = new HashSet<RequestAdditionServiceGroupNote>();
            RequestAdditionServices = new HashSet<RequestAdditionService>();
            RequestInvoices = new HashSet<RequestInvoice>();
            RequestNotes = new HashSet<RequestNote>();
            RequestPackings = new HashSet<RequestPacking>();
            RequestPayments = new HashSet<RequestPayment>();
            RequestPhotos = new HashSet<RequestPhoto>();
            RequestRooms = new HashSet<RequestRoom>();
            RequestTimeTrackings = new HashSet<RequestTimeTracking>();
            SignedAgreementDocuments = new HashSet<SignedAgreementDocument>();
        }

        [Key]
        public int Id { get; set; }
        public int MovingCustomerId { get; set; }
        public int AssignToId { get; set; }
        public int MoveFromId { get; set; }
        public bool? IsFlexibility { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AnticipatedMoveDate { get; set; }
        public int Status { get; set; }
        [StringLength(20)]
        public string RequestNo { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime RequestDate { get; set; }
        public bool? IsPhoneQuote { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ActualMoveDate { get; set; }
        public bool? IsBindingMove { get; set; }
        public bool? IsLocalOrGeneralMove { get; set; }
        public bool? IsEconomy { get; set; }
        public bool? IsConsignment { get; set; }
        public bool? IsCleaning { get; set; }
        public bool? IsMaterialTaxable { get; set; }
        public double? MaterialTaxValue { get; set; }
        public bool? IsSigned { get; set; }
        public int? EditingType { get; set; }
        public string? InvoiceNote { get; set; }
        public bool? IsInvoiceMaterialSummary { get; set; }
        public int CreatedById { get; set; }
        public int LastUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
        public byte[] LastModified { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime LastTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastTimeNote { get; set; }
        [StringLength(500)]
        public string? MaterialSummaryNote { get; set; }

        [ForeignKey("AssignToId")]
        [InverseProperty("Requests")]
        public virtual User AssignTo { get; set; } = null!;
        [ForeignKey("MoveFromId")]
        [InverseProperty("Requests")]
        public virtual Location MoveFrom { get; set; } = null!;
        [ForeignKey("MovingCustomerId")]
        [InverseProperty("Requests")]
        public virtual MovingCustomer MovingCustomer { get; set; } = null!;
        [InverseProperty("Request")]
        public virtual ICollection<Destination> Destinations { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestAdditionServiceGroupNote> RequestAdditionServiceGroupNotes { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestAdditionService> RequestAdditionServices { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestInvoice> RequestInvoices { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestNote> RequestNotes { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestPacking> RequestPackings { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestPayment> RequestPayments { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestPhoto> RequestPhotos { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestRoom> RequestRooms { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<RequestTimeTracking> RequestTimeTrackings { get; set; }
        [InverseProperty("Request")]
        public virtual ICollection<SignedAgreementDocument> SignedAgreementDocuments { get; set; }
    }
}
