using Inventory.Domain.Models;
using Inventory.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
               
        public IUnitOfWork UnitOfWork => _context;

        private readonly InventoryContext _context;

        public ItemRepository(InventoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Item Add(Item item)
        {
            return _context.Items.Add(item).Entity;
        }

              public void Update(Item order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }
    }
}
