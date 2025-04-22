using OrchardCore.Commerce.MoneyDataType;

namespace OrchardCore.Commerce.Abstractions.Models;

/// <summary>
/// A price with a priority level.
/// </summary>
public class PrioritizedPrice
{
    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    public Amount Price { get; set; }

    /// <summary>
    /// Gets or sets the priority level. Higher values take precedence.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Gets or sets the quantity threshold for bulk pricing. If set, this price will be used when the quantity
    /// is greater than or equal to this value.
    /// </summary>
    public int? QuantityThreshold { get; set; }
} 