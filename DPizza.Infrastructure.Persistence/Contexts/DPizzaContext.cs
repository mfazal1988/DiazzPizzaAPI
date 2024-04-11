using DPizza.Application.Interfaces;
using DPizza.Domain.Common;
using DPizza.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPizza.Infrastructure.Persistence.Contexts
{
    public class DPizzaContext : DbContext // Define a class named DPizzaContext that inherits from DbContext
    {
        private readonly IAuthenticatedUserService authenticatedUser; // Declare a private field to store an instance of IAuthenticatedUserService

        public DPizzaContext(DbContextOptions<DPizzaContext> options, IAuthenticatedUserService authenticatedUser) : base(options) // Constructor that takes DbContextOptions and IAuthenticatedUserService as parameters
        {
            this.authenticatedUser = authenticatedUser; // Assign the provided authenticatedUser to the private field

            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<BranchDetail> BranchDetail { get; set; }
        public DbSet<CrustType> CrustType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderRecipient> OrderRecipient { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderType> OrderType { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<ProductPrice> ProductPrice { get; set; }
        public DbSet<ProductVarient> ProductVarient { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<Product> Products { get; set; }       
        public DbSet<ProductCategory> ProductCategory { get; set; }
        
    

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) // Override the SaveChangesAsync method
        {
            var userId = Guid.Parse(authenticatedUser.UserId ?? "00000000-0000-0000-0000-000000000000"); // Get the user ID from the authenticatedUser
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>()) // Iterate over all tracked entities of type AuditableBaseEntity
            {
                switch (entry.State) // Check the state of each entity
                {
                    case EntityState.Added: // If the entity is being added
                        entry.Entity.CreatedDate = DateTime.Now; // Set the Created property to the current date and time
                        entry.Entity.CreatedBy = userId; // Set the CreatedBy property to the user ID
                        break;
                    case EntityState.Modified: // If the entity is being modified
                        entry.Entity.LastModifiedDate = DateTime.Now; // Set the LastModified property to the current date and time
                        entry.Entity.LastModifiedBy = userId; // Set the LastModifiedBy property to the user ID
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken); // Call the base SaveChangesAsync method with the provided cancellation token
        }

        protected override void OnModelCreating(ModelBuilder builder) // Override the OnModelCreating method
        {
            // All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes() // Iterate over all entity types in the model
                .SelectMany(t => t.GetProperties()) // Select all properties of each entity type
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?))) // Filter properties that are of type decimal or decimal?
            {
                property.SetColumnType("decimal(18,6)"); // Set the column type for decimal properties to "decimal(18,6)"
            }
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly); // Apply entity configurations from the current assembly

            base.OnModelCreating(builder); // Call the base OnModelCreating method with the provided ModelBuilder
        }
    }
}
