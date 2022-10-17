using Inventory.Domain.Models;
using Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Application.Queries
{
    public class ItemQueries : IItemQueries
    {

        private readonly InventoryContext _context;

        public ItemQueries(InventoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Item> GetItemAsync(string name)
        {
            return await _context.Items.Where(t => t.Name == name).FirstOrDefaultAsync();
        }
    }
}
