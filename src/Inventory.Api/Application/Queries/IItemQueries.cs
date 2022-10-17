using Inventory.Domain.Models;

namespace Inventory.Api.Application.Queries
{
    public interface IItemQueries
    {
        Task<Item> GetItemAsync(string name);
    }
}
