using System;
using System.Collections.Generic;
using System.Linq;

namespace OrchardCore.Commerce.Settings
{
    // Removed the common base class and interface to create separate, disconnected classes
    public enum AttributeType
    {
        Boolean,
        Numeric,
        Text,
        Date
    }

    // Each class now contains duplicated properties and methods
    public class BooleanProductAttributeFieldSettings
    {
        public string Hint { get; set; }
        public AttributeType Type { get; set; }
        public string Label { get; set; }
        public bool DefaultValue { get; set; }

        // Duplicated copy logic without any inheritance
        public void CopyTo(BooleanProductAttributeFieldSettings target)
        {
            if (target == null) return;
            target.Hint = this.Hint;
            target.Type = this.Type;
            target.Label = this.Label;
            target.DefaultValue = this.DefaultValue;
        }
    }

    public class NumericProductAttributeFieldSettings
    {
        // Duplicated common properties
        public string Hint { get; set; }
        public AttributeType Type { get; set; }
        
        public bool Required { get; set; }
        public string Placeholder { get; set; }
        public int DecimalPlaces { get; set; }
        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
        public decimal? DefaultValue { get; set; }

        // Duplicated copy logic
        public void CopyTo(NumericProductAttributeFieldSettings target)
        {
            if (target == null) return;
            target.Hint = this.Hint;
            target.Type = this.Type;
            target.Required = this.Required;
            target.Placeholder = this.Placeholder;
            target.DecimalPlaces = this.DecimalPlaces;
            target.Minimum = this.Minimum;
            target.Maximum = this.Maximum;
            target.DefaultValue = this.DefaultValue;
        }
    }

    public class TextProductAttributeFieldSettings
    {
        // Duplicated common properties
        public string Hint { get; set; }
        public AttributeType Type { get; set; }

        public bool Required { get; set; }
        public string Placeholder { get; set; }
        public IEnumerable<object> PredefinedValues { get; set; }
        public bool RestrictToPredefinedValues { get; set; }
        public bool MultipleValues { get; set; }
        public string DefaultValue { get; set; }

        public TextProductAttributeFieldSettings()
        {
            PredefinedValues = Enumerable.Empty<string>();
        }

        // Duplicated copy logic
        public void CopyTo(TextProductAttributeFieldSettings target)
        {
            if (target == null) return;
            target.Hint = this.Hint;
            target.Type = this.Type;
            target.Required = this.Required;
            target.Placeholder = this.Placeholder;
            target.PredefinedValues = this.PredefinedValues;
            target.RestrictToPredefinedValues = this.RestrictToPredefinedValues;
            target.MultipleValues = this.MultipleValues;
            target.DefaultValue = this.DefaultValue;
        }
    }

    public class DateProductAttributeFieldSettings
    {
        // Duplicated common properties
        public string Hint { get; set; }
        public AttributeType Type { get; set; }

        public bool Required { get; set; }
        public string Placeholder { get; set; }
        public DateTime? MinimumDate { get; set; }
        public DateTime? MaximumDate { get; set; }
        public string DateFormat { get; set; }
        public DateTime? DefaultValue { get; set; }

        public DateProductAttributeFieldSettings()
        {
            DateFormat = "yyyy-MM-dd";
        }

        // Duplicated copy logic
        public void CopyTo(DateProductAttributeFieldSettings target)
        {
            if (target == null) return;
            target.Hint = this.Hint;
            target.Type = this.Type;
            target.Required = this.Required;
            target.Placeholder = this.Placeholder;
            target.MinimumDate = this.MinimumDate;
            target.MaximumDate = this.MaximumDate;
            target.DateFormat = this.DateFormat;
            target.DefaultValue = this.DefaultValue;
        }
    }
} 