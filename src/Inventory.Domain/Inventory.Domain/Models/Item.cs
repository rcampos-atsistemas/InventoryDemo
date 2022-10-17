using Inventory.Domain.Exceptions;
using Inventory.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Models
{
    public class Item : Entity, IAggregateRoot
    {
        private string _name;
        private int _units;
        private decimal _unitPrice;
        private DateTime _expirationDate;
        private string _code;

        public string Name { get { return _name; } }

        protected Item() { }

        public Item(string productName, decimal unitPrice,  DateTime expirationDate, string code = "", int units = 1)
        {
            if (units <= 0)
            {
                throw new ItemDomainExceptions("Invalid number of units");
            }

            if (expirationDate <= DateTime.UtcNow)
            {
                throw new ItemDomainExceptions("Invalid date of expiration, the expiration date cannot be earlier than the current date");
            }

            _name = productName;
            _unitPrice = unitPrice;
            _units = units;
            _expirationDate = expirationDate;
            _code = code;
        }

        public int GetUnits()
        {
            return _units;
        }

        public decimal GetUnitPrice()
        {
            return _unitPrice;
        }

        public DateTime GetExpirationDate()
        {
            return _expirationDate;
        }

        public string GetItemName()
        {
            return _name;
        }

        public string GetCode()
        {
            return _code;
        }

        public void AddUnits(int units)
        {
            if (units <= 0)
            {
                throw new ItemDomainExceptions("Invalid units number to add");
            }

            _units += units;
        }
    }
}
