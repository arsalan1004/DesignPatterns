using OrchardCore.Commerce.Abstractions;
using OrchardCore.Commerce.Abstractions.Models;
using OrchardCore.Commerce.MoneyDataType;
using System.Collections.Generic;
using System.Linq;

namespace OrchardCore.Commerce.Services;

/// <summary>
/// A price selection strategy that selects prices based on quantity thresholds for bulk purchases.
/// </summary>
/// <remarks>
/// <para>
/// This strategy will select the appropriate price based on the quantity of items being purchased.
/// It will look for prices with quantity thresholds and select the one that matches the current quantity.
/// If no matching threshold is found, it will fall back to the highest priority price.
/// </para>
/// </remarks>
public class BulkPriceStrategy : IPriceSelectionStrategy
{
    private readonly int _quantity;

    public BulkPriceStrategy(int quantity)
    {
        _quantity = quantity;
    }

    public Amount SelectPrice(IEnumerable<PrioritizedPrice> prices)
    {
        var priceCollection = prices as ICollection<PrioritizedPrice> ?? prices?.ToList();
        if (priceCollection?.Count == 0) return Amount.Unspecified;

        // First try to find a price with a matching quantity threshold
        var bulkPrice = priceCollection
            .Where(p => p.QuantityThreshold.HasValue && p.QuantityThreshold.Value <= _quantity)
            .OrderByDescending(p => p.QuantityThreshold)
            .FirstOrDefault();

        if (bulkPrice != null)
        {
            return bulkPrice.Price;
        }

        // If no bulk price is found, fall back to the highest priority price
        return priceCollection
            .GroupBy(prioritizedPrice => prioritizedPrice.Priority)
            .OrderByDescending(group => group.Key)
            .First()
            .Min(prioritizedPrice => prioritizedPrice.Price);
    }
} 