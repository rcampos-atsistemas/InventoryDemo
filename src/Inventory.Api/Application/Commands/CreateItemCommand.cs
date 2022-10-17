using MediatR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Inventory.Api.Application.Commands
{
    
    public class CreateItemCommand:IRequest<bool>
    {
              
        public string Name { get; set; }
               
        public decimal UnitPrice { get;  set; }

        public int Units { get;  set; }
               
        public DateTime ExpirationDate { get;  set; }
               
        public string Code { get;  set; }

        public CreateItemCommand() { }

   
        public CreateItemCommand(string name,  decimal unitPrice, int numUnits, DateTime dateExpiration, string code)
        {
            Name = name;
            UnitPrice = unitPrice;
            Units = numUnits;
            ExpirationDate = dateExpiration;
            Code = code;
        }
    }
}
