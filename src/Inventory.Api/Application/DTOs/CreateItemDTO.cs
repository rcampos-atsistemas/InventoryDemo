using System.Text.Json.Serialization;

namespace Inventory.Api.Application.DTOs
{
    public class CreateItemDTO
    {
       
        public string Name { get; set; }

        
        public decimal UnitPrice { get; set; }

      
        public int Units { get; set; }

      
        public DateTime ExpirationDate { get; set; }

        
        public string Code { get; set; }

    }
}
