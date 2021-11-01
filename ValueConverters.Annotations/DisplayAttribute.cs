using System;
using System.Linq;
using System.Reflection;

namespace ValueConverters.Annotations
{
    /// <summary>
    /// Source: Mono and .Net Reference Source
    /// https://searchcode.com/codesearch/view/7229840/
    /// http://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/DisplayAttribute.cs
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Method, AllowMultiple = false)]
    public class DisplayAttribute : Attribute
    {
        const string PropertyNotSetMessage = "The {0} property has not been set.  Use the Get{0} method to get the value.";

        bool? autoGenerateField;
        bool? autoGenerateFilter;
        int? order;

        public Type ResourceType { get; set; }

        public string Description { get; set; }

        public string GroupName { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Prompt { get; set; }

        public bool AutoGenerateField
        {
            get
            {
                if (!this.autoGenerateField.HasValue)
                {
                    throw new InvalidOperationException(string.Format(PropertyNotSetMessage, nameof(this.AutoGenerateField)));
                }

                return this.autoGenerateField.Value;
            }
            set
            {
                this.autoGenerateField = value;
            }
        }

        public bool AutoGenerateFilter
        {
            get
            {
                if (this.autoGenerateFilter == null)
                {
                    throw new InvalidOperationException(string.Format(PropertyNotSetMessage, nameof(this.AutoGenerateFilter)));
                }

                return this.autoGenerateFilter.Value;
            }
            set
            {
                this.autoGenerateFilter = value;
            }
        }

        public int Order
        {
            get
            {
                if (this.order == null)
                {
                    throw new InvalidOperationException(string.Format(PropertyNotSetMessage, nameof(this.Order)));
                }

                return this.order.Value;
            }
            set
            {
                this.order = value;
            }
        }

        private string GetLocalizedString(string propertyName, string key)
        {
            // If we don't have a resource or a key, go ahead and fall back on the key
            if (this.ResourceType == null || key == null)
            {
                return key;
            }

            var property = this.ResourceType.GetRuntimeProperty(key);
            if (property == null)
            {
                // In case the .resx is generated with ResXFileCodeGenerator instead of PublicResXFileCodeGenerator.
                property = this.ResourceType.GetTypeInfo().DeclaredProperties.FirstOrDefault(x => x.Name == key);
            }

            // Strings are only valid if they are public static strings
            var isValid = false;
            if (property != null && property.PropertyType == typeof(string))
            {
                var getter = property.GetMethod;

                // Gotta have a public static getter on the property
                if (getter != null && getter.IsStatic)
                {
                    isValid = true;
                }
            }

            // If it's not valid, go ahead and throw an InvalidOperationException
            if (!isValid)
            {
                var message =
                    $"Cannot retrieve property '{propertyName}' because localization failed. " +
                    $"Type '{this.ResourceType} is not public or does not contain a public static string property with the name '{key}'.";
                throw new InvalidOperationException(message);
            }

            return (string)property.GetValue(null, null);
        }

        public bool? GetAutoGenerateField()
        {
            return this.autoGenerateField;
        }

        public bool? GetAutoGenerateFilter()
        {
            return this.autoGenerateFilter;
        }

        public int? GetOrder()
        {
            return this.order;
        }

        public string GetName()
        {
            return this.GetLocalizedString(nameof(this.Name), this.Name);
        }

        public string GetShortName()
        {
            // Short name falls back on Name if the short name isn't set
            return this.GetLocalizedString(nameof(this.ShortName), this.ShortName) ?? this.GetName();
        }

        public string GetDescription()
        {
            return this.GetLocalizedString(nameof(this.Description), this.Description);
        }

        public string GetPrompt()
        {
            return this.GetLocalizedString(nameof(this.Prompt), this.Prompt);
        }

        public string GetGroupName()
        {
            return this.GetLocalizedString(nameof(this.GroupName), this.GroupName);
        }
    }
}