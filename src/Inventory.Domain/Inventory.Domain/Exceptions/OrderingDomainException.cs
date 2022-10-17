namespace Inventory.Domain.Exceptions;

/// <summary>
/// Exception type for domain exceptions
/// </summary>
public class ItemDomainExceptions : Exception
{
    public ItemDomainExceptions()
    { }

    public ItemDomainExceptions(string message)
        : base(message)
    { }

    public ItemDomainExceptions(string message, Exception innerException)
        : base(message, innerException)
    { }
}
