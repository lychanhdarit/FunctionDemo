using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.MoverRepository.Models;

namespace Data.MoverRepository
{
    public partial class dbDataMoverContext : DbContext
    {
        public dbDataMoverContext()
        {
        }

        public dbDataMoverContext(DbContextOptions<dbDataMoverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionServiceItem> AdditionServiceItems { get; set; } = null!;
        public virtual DbSet<AdditionServiceItemDetail> AdditionServiceItemDetails { get; set; } = null!;
        public virtual DbSet<AdditionServiceItemDetailBinding> AdditionServiceItemDetailBindings { get; set; } = null!;
        public virtual DbSet<AdditionServiceType> AdditionServiceTypes { get; set; } = null!;
        public virtual DbSet<Auction> Auctions { get; set; } = null!;
        public virtual DbSet<AuctionCustomer> AuctionCustomers { get; set; } = null!;
        public virtual DbSet<AuctionItem> AuctionItems { get; set; } = null!;
        public virtual DbSet<AuctionItemSold> AuctionItemSolds { get; set; } = null!;
        public virtual DbSet<AuctionSession> AuctionSessions { get; set; } = null!;
        public virtual DbSet<AuditHistory> AuditHistories { get; set; } = null!;
        public virtual DbSet<Bid> Bids { get; set; } = null!;
        public virtual DbSet<Bidder> Bidders { get; set; } = null!;
        public virtual DbSet<ConsignmentInvoice> ConsignmentInvoices { get; set; } = null!;
        public virtual DbSet<ConsignmentInvoiceDetail> ConsignmentInvoiceDetails { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAgreementDocument> CustomerAgreementDocuments { get; set; } = null!;
        public virtual DbSet<CustomerCode> CustomerCodes { get; set; } = null!;
        public virtual DbSet<CustomerDocument> CustomerDocuments { get; set; } = null!;
        public virtual DbSet<CustomerFollow> CustomerFollows { get; set; } = null!;
        public virtual DbSet<CustomerItemCode> CustomerItemCodes { get; set; } = null!;
        public virtual DbSet<CustomerNote> CustomerNotes { get; set; } = null!;
        public virtual DbSet<CustomerPhoto> CustomerPhotos { get; set; } = null!;
        public virtual DbSet<DamageOfItem> DamageOfItems { get; set; } = null!;
        public virtual DbSet<DamageType> DamageTypes { get; set; } = null!;
        public virtual DbSet<Descriptive> Descriptives { get; set; } = null!;
        public virtual DbSet<Destination> Destinations { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<FranchiseeConfig> FranchiseeConfigs { get; set; } = null!;
        public virtual DbSet<GridConfig> GridConfigs { get; set; } = null!;
        public virtual DbSet<Helper> Helpers { get; set; } = null!;
        public virtual DbSet<InventoryItem> InventoryItems { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<ItemPhoto> ItemPhotos { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<MaxBid> MaxBids { get; set; } = null!;
        public virtual DbSet<MoveContact> MoveContacts { get; set; } = null!;
        public virtual DbSet<MovingCustomer> MovingCustomers { get; set; } = null!;
        public virtual DbSet<MovingItem> MovingItems { get; set; } = null!;
        public virtual DbSet<PackageSize> PackageSizes { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<RequestAdditionService> RequestAdditionServices { get; set; } = null!;
        public virtual DbSet<RequestAdditionServiceGroupNote> RequestAdditionServiceGroupNotes { get; set; } = null!;
        public virtual DbSet<RequestInvoice> RequestInvoices { get; set; } = null!;
        public virtual DbSet<RequestItemDescriptive> RequestItemDescriptives { get; set; } = null!;
        public virtual DbSet<RequestItemPhoto> RequestItemPhotos { get; set; } = null!;
        public virtual DbSet<RequestItemRoom> RequestItemRooms { get; set; } = null!;
        public virtual DbSet<RequestNote> RequestNotes { get; set; } = null!;
        public virtual DbSet<RequestPacking> RequestPackings { get; set; } = null!;
        public virtual DbSet<RequestPayment> RequestPayments { get; set; } = null!;
        public virtual DbSet<RequestPhoto> RequestPhotos { get; set; } = null!;
        public virtual DbSet<RequestRoom> RequestRooms { get; set; } = null!;
        public virtual DbSet<RequestTimeTracking> RequestTimeTrackings { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomItem> RoomItems { get; set; } = null!;
        public virtual DbSet<RoomPacking> RoomPackings { get; set; } = null!;
        public virtual DbSet<SecurityOperation> SecurityOperations { get; set; } = null!;
        public virtual DbSet<SignedAgreementDocument> SignedAgreementDocuments { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<StaticValue> StaticValues { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreAssociateUser> StoreAssociateUsers { get; set; } = null!;
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; } = null!;
        public virtual DbSet<Template> Templates { get; set; } = null!;
        public virtual DbSet<UploadFile> UploadFiles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserRoleFunction> UserRoleFunctions { get; set; } = null!;
        public virtual DbSet<Zone> Zones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=HarmonyFranchisee;MultipleActiveResultSets=true;User ID=sa;Password=Vn@2022@;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionServiceItem>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AdditionServiceType)
                    .WithMany(p => p.AdditionServiceItems)
                    .HasForeignKey(d => d.AdditionServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionServiceItem_AdditonServiceType");
            });

            modelBuilder.Entity<AdditionServiceItemDetail>(entity =>
            {
                entity.Property(e => e.AutoChangeType).HasComment("1. Room Paking Time, 2. Room Moving Time");

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AdditionServiceItem)
                    .WithMany(p => p.AdditionServiceItemDetails)
                    .HasForeignKey(d => d.AdditionServiceItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionServiceItemDetail_AdditionServiceItem");
            });

            modelBuilder.Entity<AdditionServiceItemDetailBinding>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AdditionServiceItem)
                    .WithMany(p => p.AdditionServiceItemDetailBindings)
                    .HasForeignKey(d => d.AdditionServiceItemId)
                    .HasConstraintName("FK_AdditionServiceItemDetailBinding_AdditionServiceItem");
            });

            modelBuilder.Entity<AdditionServiceType>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Auction>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Auctions)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Auction_Store");
            });

            modelBuilder.Entity<AuctionCustomer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.BillingLocation)
                    .WithMany(p => p.AuctionCustomerBillingLocations)
                    .HasForeignKey(d => d.BillingLocationId)
                    .HasConstraintName("FK_AuctionCustomer_Location");

                entity.HasOne(d => d.Consignment)
                    .WithMany(p => p.AuctionCustomerConsignments)
                    .HasForeignKey(d => d.ConsignmentId)
                    .HasConstraintName("FK_AuctionCustomer_UploadFile1");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AuctionCustomer)
                    .HasForeignKey<AuctionCustomer>(d => d.Id)
                    .HasConstraintName("FK_AuctionCustomer_Customer");

                entity.HasOne(d => d.ShippingLocation)
                    .WithMany(p => p.AuctionCustomerShippingLocations)
                    .HasForeignKey(d => d.ShippingLocationId)
                    .HasConstraintName("FK_AuctionCustomer_Location1");

                entity.HasOne(d => d.TaxDocument)
                    .WithMany(p => p.AuctionCustomerTaxDocuments)
                    .HasForeignKey(d => d.TaxDocumentId)
                    .HasConstraintName("FK_AuctionCustomer_UploadFile");
            });

            modelBuilder.Entity<AuctionItem>(entity =>
            {
                entity.Property(e => e.AuctionItemCode).IsFixedLength();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.AuctionItems)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionAssociateItem_Auction");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.AuctionItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionItem_InventoryItem");
            });

            modelBuilder.Entity<AuctionItemSold>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Bid)
                    .WithMany(p => p.AuctionItemSolds)
                    .HasForeignKey(d => d.BidId)
                    .HasConstraintName("FK_AuctionItemSold_Bid");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.AuctionItemSold)
                    .HasForeignKey<AuctionItemSold>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionItemSold_AuctionAssociateItem");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.AuctionItemSolds)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuctionItemSold_Invoice");
            });

            modelBuilder.Entity<AuctionSession>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.AuctionSessions)
                    .HasForeignKey(d => d.AuctionId)
                    .HasConstraintName("FK_AuctionSession_Auction");
            });

            modelBuilder.Entity<AuditHistory>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuctionItem)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.AuctionItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bid_AuctionAssociateItem");

                entity.HasOne(d => d.Bidder)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.BidderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bid_Bidder");
            });

            modelBuilder.Entity<Bidder>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.Bidders)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bidder_Auction");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bidders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Bidder_AuctionCustomer");
            });

            modelBuilder.Entity<ConsignmentInvoice>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConsignmentInvoiceDetail>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ConsignmentInvoice)
                    .WithMany(p => p.ConsignmentInvoiceDetails)
                    .HasForeignKey(d => d.ConsignmentInvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsignmentInvoiceDetail_ConsignmentInvoice");

                entity.HasOne(d => d.InventoryItem)
                    .WithMany(p => p.ConsignmentInvoiceDetails)
                    .HasForeignKey(d => d.InventoryItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsignmentInvoiceDetail_InventoryItem");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Id)
                    .HasConstraintName("FK_Customer_User");
            });

            modelBuilder.Entity<CustomerAgreementDocument>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.UploadFile)
                    .WithMany(p => p.CustomerAgreementDocuments)
                    .HasForeignKey(d => d.UploadFileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CustomerAgreementDocument_UploadFile1");
            });

            modelBuilder.Entity<CustomerCode>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CustomerDocument>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerDocuments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerDocument_Customer1");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CustomerDocument)
                    .HasForeignKey<CustomerDocument>(d => d.Id)
                    .HasConstraintName("FK_CustomerDocument_UploadFile");
            });

            modelBuilder.Entity<CustomerFollow>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuctionItem)
                    .WithMany(p => p.CustomerFollows)
                    .HasForeignKey(d => d.AuctionItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerFollow_AuctionAssociateItem");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerFollows)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerFollow_AuctionCustomer");
            });

            modelBuilder.Entity<CustomerItemCode>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CustomerNote>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerNotes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerNote_Customer1");
            });

            modelBuilder.Entity<CustomerPhoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPhotos)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerPhoto_Customer");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.CustomerPhoto)
                    .HasForeignKey<CustomerPhoto>(d => d.Id)
                    .HasConstraintName("FK_CustomerPhoto_UploadFile1");
            });

            modelBuilder.Entity<DamageOfItem>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DamageType>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Descriptive>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Destination)
                    .HasForeignKey<Destination>(d => d.Id)
                    .HasConstraintName("FK_Destination_Location");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Destinations)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Destination_Request");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<FranchiseeConfig>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GridConfig>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.GridConfigs)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_GridConfig_DocumentType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GridConfigs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GridConfig_User");
            });

            modelBuilder.Entity<Helper>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_InventoryItem_Customer");

                entity.HasOne(d => d.DamageOfItem)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.DamageOfItemId)
                    .HasConstraintName("FK_InventoryItem_DamageOfItem");

                entity.HasOne(d => d.RequestItemDescriptive)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.RequestItemDescriptiveId)
                    .HasConstraintName("FK_InventoryItem_RequestItemDescriptive");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_InventoryItem_Store");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK_InventoryItem_Zone");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Bidder)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.BidderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Bidder");
            });

            modelBuilder.Entity<ItemPhoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ItemPhoto)
                    .HasForeignKey<ItemPhoto>(d => d.Id)
                    .HasConstraintName("FK_ItemPhoto_UploadFile");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemPhotos)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemPhoto_Item");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_State");
            });

            modelBuilder.Entity<MaxBid>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AuctionItem)
                    .WithMany(p => p.MaxBids)
                    .HasForeignKey(d => d.AuctionItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaxBid_AuctionAssociateItem");

                entity.HasOne(d => d.Bidder)
                    .WithMany(p => p.MaxBids)
                    .HasForeignKey(d => d.BidderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaxBid_Bidder");
            });

            modelBuilder.Entity<MoveContact>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MovingCustomer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.MovingCustomer)
                    .HasForeignKey<MovingCustomer>(d => d.Id)
                    .HasConstraintName("FK_MovingCustomer_Customer");

                entity.HasOne(d => d.MoveContact)
                    .WithMany(p => p.MovingCustomers)
                    .HasForeignKey(d => d.MoveContactId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MovingCustomer_MoveContact");
            });

            modelBuilder.Entity<MovingItem>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RequestItemRoom)
                    .WithMany(p => p.MovingItems)
                    .HasForeignKey(d => d.RequestItemRoomId)
                    .HasConstraintName("FK_MovingItem_RequestItemRoom");
            });

            modelBuilder.Entity<PackageSize>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AssignTo)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.AssignToId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_User");

                entity.HasOne(d => d.MoveFrom)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.MoveFromId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Location");

                entity.HasOne(d => d.MovingCustomer)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.MovingCustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_MovingCustomer");
            });

            modelBuilder.Entity<RequestAdditionService>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AdditionServiceItemDetail)
                    .WithMany(p => p.RequestAdditionServices)
                    .HasForeignKey(d => d.AdditionServiceItemDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestAdditionService_AdditionServiceItemDetail");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestAdditionServices)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestAdditionService_Request");
            });

            modelBuilder.Entity<RequestAdditionServiceGroupNote>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AdditionServiceType)
                    .WithMany(p => p.RequestAdditionServiceGroupNotes)
                    .HasForeignKey(d => d.AdditionServiceTypeId)
                    .HasConstraintName("FK_RequestAdditionServiceGroupNote_AdditionServiceType");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestAdditionServiceGroupNotes)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestAdditionServiceGroupNote_Request");
            });

            modelBuilder.Entity<RequestInvoice>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestInvoices)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestInvoice_Request");
            });

            modelBuilder.Entity<RequestItemDescriptive>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RequestItemPhoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RequestItemPhoto)
                    .HasForeignKey<RequestItemPhoto>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestItemPhoto_UploadFile1");

                entity.HasOne(d => d.RequestItemRoom)
                    .WithMany(p => p.RequestItemPhotos)
                    .HasForeignKey(d => d.RequestItemRoomId)
                    .HasConstraintName("FK_RequestItemPhoto_RequestItemRoom");
            });

            modelBuilder.Entity<RequestItemRoom>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DamageOfItem)
                    .WithMany(p => p.RequestItemRooms)
                    .HasForeignKey(d => d.DamageOfItemId)
                    .HasConstraintName("FK_RequestItemRoom_DamageOfItem");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.RequestItemRooms)
                    .HasForeignKey(d => d.DestinationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestItemRoom_Destination");

                entity.HasOne(d => d.RequestItemDescriptive)
                    .WithMany(p => p.RequestItemRooms)
                    .HasForeignKey(d => d.RequestItemDescriptiveId)
                    .HasConstraintName("FK_RequestItemRoom_RequestItemDescriptive");

                entity.HasOne(d => d.RequestRoom)
                    .WithMany(p => p.RequestItemRooms)
                    .HasForeignKey(d => d.RequestRoomId)
                    .HasConstraintName("FK_RequestItemRoom_RequestRoom");

                entity.HasOne(d => d.RoomItem)
                    .WithMany(p => p.RequestItemRooms)
                    .HasForeignKey(d => d.RoomItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestItemRoom_RoomItem");
            });

            modelBuilder.Entity<RequestNote>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestNotes)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestNote_Request");
            });

            modelBuilder.Entity<RequestPacking>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PackageSize)
                    .WithMany(p => p.RequestPackings)
                    .HasForeignKey(d => d.PackageSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestPacking_PackageSize");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestPackings)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestPacking_Request");
            });

            modelBuilder.Entity<RequestPayment>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestPayments)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestPayment_Request");
            });

            modelBuilder.Entity<RequestPhoto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RequestPhoto)
                    .HasForeignKey<RequestPhoto>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestPhoto_UploadFile");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestPhotos)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestPhoto_Request");
            });

            modelBuilder.Entity<RequestRoom>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestRooms)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestRoom_Request");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RequestRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestRoom_Room");
            });

            modelBuilder.Entity<RequestTimeTracking>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Helper)
                    .WithMany(p => p.RequestTimeTrackings)
                    .HasForeignKey(d => d.HelperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequestTimeTracking_Helper");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestTimeTrackings)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_RequestTimeTracking_Request");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RoomItem>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomItems)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_RoomItem_Room");
            });

            modelBuilder.Entity<RoomPacking>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PackageSize)
                    .WithMany(p => p.RoomPackings)
                    .HasForeignKey(d => d.PackageSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomPacking_PackageItem");

                entity.HasOne(d => d.RequestRoom)
                    .WithMany(p => p.RoomPackings)
                    .HasForeignKey(d => d.RequestRoomId)
                    .HasConstraintName("FK_RoomPacking_RequestRoom");
            });

            modelBuilder.Entity<SecurityOperation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SignedAgreementDocument>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CustomerAgreementDocument)
                    .WithMany(p => p.SignedAgreementDocuments)
                    .HasForeignKey(d => d.CustomerAgreementDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SignedAgreementDocument_CustomerAgreementDocument");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.SignedAgreementDocuments)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_SignedAgreementDocument_Request");

                entity.HasOne(d => d.UploadFile)
                    .WithMany(p => p.SignedAgreementDocuments)
                    .HasForeignKey(d => d.UploadFileId)
                    .HasConstraintName("FK_SignedAgreementDocument_UploadFile");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<StaticValue>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Store_Location");
            });

            modelBuilder.Entity<StoreAssociateUser>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreAssociateUsers)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreAssociateUser_Store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StoreAssociateUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreAssociateUser_User");
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<UploadFile>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.GroupKeySearch).IsFixedLength();

                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_User_Location1");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole1");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UserRoleFunction>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.UserRoleFunctions)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_UserRoleFunction_DocumentType");

                entity.HasOne(d => d.SecurityOperation)
                    .WithMany(p => p.UserRoleFunctions)
                    .HasForeignKey(d => d.SecurityOperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoleFunction_SecurityOperation");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.UserRoleFunctions)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_UserRoleFunction_UserRole");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.Property(e => e.LastModified)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.LastTime).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
