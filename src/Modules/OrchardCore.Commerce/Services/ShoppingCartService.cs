/// <summary>
/// Calculates the total price for a shopping cart item using bulk pricing if applicable.
/// </summary>
/// <param name="item">The shopping cart item.</param>
/// <returns>The total price for the item.</returns>
public async Task<Amount> CalculateItemTotalWithBulkPricingAsync(ShoppingCartItem item)
{
    var prices = await _priceService.GetPricesAsync(item.ProductSku);
    var strategy = new BulkPriceStrategy(item.Quantity);
    var selectedPrice = strategy.SelectPrice(prices);
    return item.Quantity * selectedPrice;
} 