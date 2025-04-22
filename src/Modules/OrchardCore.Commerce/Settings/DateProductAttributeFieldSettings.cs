using Lombiq.HelpfulLibraries.Common.Utilities;
using OrchardCore.Commerce.Abstractions;
using System;

namespace OrchardCore.Commerce.Settings;

/// <summary>
/// Settings for the date product attribute.
/// </summary>
public class DateProductAttributeFieldSettings : ProductAttributeFieldSettings<DateTime?>, ICopier<DateProductAttributeFieldSettings>
{
    /// <summary>
    /// Gets or sets a value indicating whether a value is required.
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    /// Gets or sets the hint to display when the input is empty.
    /// </summary>
    public string Placeholder { get; set; }

    /// <summary>
    /// Gets or sets the minimum date allowed.
    /// </summary>
    public DateTime? MinimumDate { get; set; }

    /// <summary>
    /// Gets or sets the maximum date allowed.
    /// </summary>
    public DateTime? MaximumDate { get; set; }

    /// <summary>
    /// Gets or sets the format to display the date.
    /// </summary>
    public string DateFormat { get; set; } = "yyyy-MM-dd";

    public void CopyTo(DateProductAttributeFieldSettings target)
    {
        ((ProductAttributeFieldSettings<DateTime?>)this).CopyTo(target);

        target.Required = Required;
        target.Placeholder = Placeholder;
        target.MinimumDate = MinimumDate;
        target.MaximumDate = MaximumDate;
        target.DateFormat = DateFormat;
    }
} 