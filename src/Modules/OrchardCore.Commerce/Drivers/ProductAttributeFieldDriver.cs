using Microsoft.Extensions.Localization;
using OrchardCore.Commerce.Fields;
using OrchardCore.Commerce.Settings;
using OrchardCore.Commerce.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.Views;

namespace OrchardCore.Commerce.Drivers;

public class ProductAttributeFieldDriver : ContentFieldDisplayDriver<ProductAttributeField>
{
    private readonly IStringLocalizer<ProductAttributeFieldDriver> _localizer;

    public ProductAttributeFieldDriver(IStringLocalizer<ProductAttributeFieldDriver> localizer)
    {
        _localizer = localizer;
    }

    public override IDisplayResult Edit(ProductAttributeField field, BuildFieldEditorContext context)
    {
        return Initialize<EditProductAttributeFieldViewModel>(
            GetEditorShapeType(context),
            model =>
            {
                model.Field = field;
                model.Settings = field.Settings;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
            });
    }
}

public class BooleanProductAttributeFieldDriver
    : ProductAttributeFieldDriver<BooleanProductAttributeField, BooleanProductAttributeFieldSettings>
{
    public BooleanProductAttributeFieldDriver(
        IStringLocalizer<
            ProductAttributeFieldDriver<BooleanProductAttributeField, BooleanProductAttributeFieldSettings>> localizer)
        : base(localizer)
    {
    }
}

public class NumericProductAttributeFieldDriver
    : ProductAttributeFieldDriver<NumericProductAttributeField, NumericProductAttributeFieldSettings>
{
    public NumericProductAttributeFieldDriver(
        IStringLocalizer<
            ProductAttributeFieldDriver<NumericProductAttributeField, NumericProductAttributeFieldSettings>> localizer)
        : base(localizer)
    {
    }
}

public class TextProductAttributeFieldDriver
    : ProductAttributeFieldDriver<TextProductAttributeField, TextProductAttributeFieldSettings>
{
    public TextProductAttributeFieldDriver(
        IStringLocalizer<
            ProductAttributeFieldDriver<TextProductAttributeField, TextProductAttributeFieldSettings>> localizer)
        : base(localizer)
    {
    }
}
