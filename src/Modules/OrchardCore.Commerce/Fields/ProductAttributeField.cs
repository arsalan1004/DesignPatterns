using Lombiq.HelpfulLibraries.Common.Utilities;
using OrchardCore.Commerce.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;
using System;

namespace OrchardCore.Commerce.Fields;

/// <summary>
/// Represents a product attribute field that can be of different types (Boolean, Numeric, Text, Date).
/// </summary>
public class ProductAttributeField : ContentField
{
    /// <summary>
    /// Gets or sets the type of the attribute.
    /// </summary>
    public AttributeType Type { get; set; }

    /// <summary>
    /// Gets or sets the settings for the attribute.
    /// </summary>
    public ProductAttributeFieldSettings Settings { get; set; }

    /// <summary>
    /// Gets the settings of the specified type.
    /// </summary>
    public TSettings GetSettings<TSettings>(ContentPartFieldDefinition partFieldDefinition)
        where TSettings : ProductAttributeFieldSettings, ICopier<TSettings>, new()
    {
        return partFieldDefinition.GetSettings<TSettings>();
    }
}

/// <summary>
/// Defines the possible types of product attributes.
/// </summary>
public enum AttributeType
{
    Boolean,
    Numeric,
    Text,
    Date
}

/// <summary>
/// Adds the ability for a product to be modified with a set of attributes, in particular when added to a shopping cart.
/// </summary>
/// <remarks>
/// <para>Examples of attributes can be shirt sizes (S, M, L, XL), dimensions, etc.</para>
/// </remarks>
public abstract class ProductAttributeField<TSettings> : ProductAttributeField
    where TSettings : ProductAttributeFieldSettings, ICopier<TSettings>, new()
{
}

/// <summary>
/// A Boolean product attribute.
/// </summary>
public class BooleanProductAttributeField : ProductAttributeField<BooleanProductAttributeFieldSettings>
{
}

/// <summary>
/// A numeric product attribute.
/// </summary>
public class NumericProductAttributeField : ProductAttributeField<NumericProductAttributeFieldSettings>
{
}

/// <summary>
/// A text product attribute, that may also have predefined values and may be used as enumeration or flags.
/// </summary>
public class TextProductAttributeField : ProductAttributeField<TextProductAttributeFieldSettings>
{
}
