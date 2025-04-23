using System;
using OrchardCore.Commerce.Fields;
using OrchardCore.Commerce.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace OrchardCore.Commerce.ViewModels;

public class DisplayDateProductAttributeFieldViewModel
{
    public DateProductAttributeField Field { get; set; }
    public ContentPart Part { get; set; }
    public ContentPartFieldDefinition PartFieldDefinition { get; set; }
}

public class EditDateProductAttributeFieldViewModel
{
    public DateProductAttributeField Field { get; set; }
    public ContentPart Part { get; set; }
    public ContentPartFieldDefinition PartFieldDefinition { get; set; }
    public DateProductAttributeFieldSettings Settings { get; set; }
    public DateTime? Value { get; set; }
} 