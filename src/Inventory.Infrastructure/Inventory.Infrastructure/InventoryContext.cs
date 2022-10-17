using Inventory.Domain.Models;
using Inventory.Domain.SeedWork;
using Inventory.Infrastructure.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure
{
    public class InventoryContext: DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "inventory";
        private IDbContextTransaction _currentTransaction;
        private readonly IMediator _mediator;

        public DbSet<Item> Items { get; set; }

       
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { 
        
        
        }

       
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public InventoryContext(DbContextOptions<InventoryContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


            System.Diagnostics.Debug.WriteLine("InventoryContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
