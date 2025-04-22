using OrchardCore.Commerce.Fields;
using OrchardCore.Commerce.Settings;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Metadata.Models;

namespace OrchardCore.Commerce.ViewModels;

public class EditProductAttributeFieldViewModel
{
    public ProductAttributeField Field { get; set; }
    public ProductAttributeFieldSettings Settings { get; set; }
    public ContentPart Part { get; set; }
    public ContentPartFieldDefinition PartFieldDefinition { get; set; }
}
