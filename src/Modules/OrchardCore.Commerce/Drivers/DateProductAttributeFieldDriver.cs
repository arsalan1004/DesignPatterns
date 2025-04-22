using Microsoft.AspNetCore.Mvc.Localization;
using OrchardCore.Commerce.Fields;
using OrchardCore.Commerce.Settings;
using OrchardCore.Commerce.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace OrchardCore.Commerce.Drivers;

public class DateProductAttributeFieldDriver
    : ProductAttributeFieldDriver<DateProductAttributeField, DateProductAttributeFieldSettings>
{
    public DateProductAttributeFieldDriver(
        IHtmlLocalizer<DateProductAttributeFieldDriver> localizer)
        : base(localizer)
    {
    }

    public override IDisplayResult Display(
        DateProductAttributeField field,
        BuildFieldDisplayContext context)
    {
        return Initialize<DisplayDateProductAttributeFieldViewModel>(
            GetDisplayShapeType(context),
            model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
            })
            .Location("Detail", "Content")
            .Location("Summary", "Content");
    }

    public override IDisplayResult Edit(
        DateProductAttributeField field,
        BuildFieldEditorContext context)
    {
        return Initialize<EditDateProductAttributeFieldViewModel>(
            GetEditorShapeType(context),
            model =>
            {
                model.Field = field;
                model.Part = context.ContentPart;
                model.PartFieldDefinition = context.PartFieldDefinition;
                model.Settings = field.GetSettings(context.PartFieldDefinition);
            });
    }

    public override async Task<IDisplayResult> UpdateAsync(
        DateProductAttributeField field,
        IUpdateModel updater,
        UpdateFieldEditorContext context)
    {
        var model = new EditDateProductAttributeFieldViewModel();

        if (await updater.TryUpdateModelAsync(model, Prefix))
        {
            field.Value = model.Value;
        }

        return Edit(field, context);
    }
} 