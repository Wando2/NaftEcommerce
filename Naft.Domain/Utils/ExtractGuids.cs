using Naft.Domain.Entities;

namespace Naft.Domain.Utils;

public static class ExtractGuids
{
    public static IEnumerable<Guid> Extract(IList<OrderItem> items )
    {
        return items.Select(item => item.Product.Id).ToList();
    }
}