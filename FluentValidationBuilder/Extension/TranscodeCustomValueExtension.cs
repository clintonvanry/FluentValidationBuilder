using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidationBuilder.Model.ActiveMessage;

namespace FluentValidationBuilder.Extension
{

    public static class TranscodeCustomValueExtension
    {
        public static bool Exists(this IList<TranscodeCustomValue> customValues, string name)
        {
            var customValue = customValues.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return customValue != null;
        }

        public static void Upsert(this IList<TranscodeCustomValue> customValues, string name, string value)
        {
            var customValue = customValues.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (customValue != null)
            {
                customValue.Value = value;
            }
            else
            {
                customValue = new TranscodeCustomValue {Name = name, Value = value};
                customValues.Add(customValue);
            }

        }
    }
}