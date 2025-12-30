using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace ValueConverters.Annotations
{
    /// <summary>
    /// DisplayAttribute is a general-purpose attribute to specify user-visible globalizable strings for types and members.
    /// The string properties of this class can be used either as literals or as resource identifiers into a specified
    /// <see cref="ResourceType"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class DisplayAttribute : Attribute
    {
        private const string PropertyNotSetMessage =
            "The {0} property has not been set. Use the Get{0} method to get the value.";

        private bool? autoGenerateField;
        private bool? autoGenerateFilter;
        private int? order;

        public Type? ResourceType { get; set; }

        public string? Name { get; set; }

        public string? ShortName { get; set; }

        public string? Description { get; set; }

        public string? Prompt { get; set; }

        public string? GroupName { get; set; }

        public bool AutoGenerateField
        {
            get => this.autoGenerateField ?? throw new InvalidOperationException(string.Format(PropertyNotSetMessage, nameof(this.AutoGenerateField)));
            set => this.autoGenerateField = value;
        }

        public bool AutoGenerateFilter
        {
            get => this.autoGenerateFilter ?? throw new InvalidOperationException(string.Format(PropertyNotSetMessage, nameof(this.AutoGenerateFilter)));
            set => this.autoGenerateFilter = value;
        }

        public int Order
        {
            get => this.order ?? throw new InvalidOperationException(string.Format(PropertyNotSetMessage, nameof(this.Order)));
            set => this.order = value;
        }

        public bool? GetAutoGenerateField()
        {
            return this.autoGenerateField;
        }

        public bool? GetAutoGenerateFilter()
        {
            return this.autoGenerateFilter;
        }

        public int? GetOrder() => this.order;

        public string? GetName(CultureInfo? culture = null)
        {
            return this.GetLocalizedString(nameof(this.Name), this.Name, culture);
        }

        public string? GetShortName(CultureInfo? culture = null)
        {
            return this.GetLocalizedString(nameof(this.ShortName), this.ShortName, culture) ?? this.GetName(culture);
        }

        public string? GetDescription(CultureInfo? culture = null)
        {
            return this.GetLocalizedString(nameof(this.Description), this.Description, culture);
        }

        public string? GetPrompt(CultureInfo? culture = null)
        {
            return this.GetLocalizedString(nameof(this.Prompt), this.Prompt, culture);
        }

        public string? GetGroupName(CultureInfo? culture = null)
        {
            return this.GetLocalizedString(nameof(this.GroupName), this.GroupName, culture);
        }

        private string? GetLocalizedString(string propertyName, string? key, CultureInfo? culture)
        {
            if (key == null || this.ResourceType == null)
            {
                return key;
            }

            culture ??= CultureInfo.CurrentUICulture;

            var resourceManager = ResourceManagerCache.Get(this.ResourceType);

            var value = resourceManager.GetString(key, culture);

            if (value == null)
            {
                throw new InvalidOperationException(
                    $"Cannot retrieve resource '{key}' for property '{propertyName}' " +
                    $"from resource type '{this.ResourceType.FullName}'.");
            }

            return value;
        }

        private static class ResourceManagerCache
        {
            private static readonly ConcurrentDictionary<Type, ResourceManager> Cache = new();

            public static ResourceManager Get(Type resourceType)
            {
                return Cache.GetOrAdd(resourceType, type =>
                {
                    var property = type.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                    if (property?.GetValue(null) is ResourceManager rm)
                    {
                        return rm;
                    }

                    throw new InvalidOperationException(
                        $"Type '{type.FullName}' does not expose a static ResourceManager property.");
                });
            }
        }
    }
}
