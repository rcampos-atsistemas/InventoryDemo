using Inventory.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Models
{
    public interface IItemRepository : IRepository<Item>
    {
        Item Add(Item item);

        void Update(Item order);

    }
}
