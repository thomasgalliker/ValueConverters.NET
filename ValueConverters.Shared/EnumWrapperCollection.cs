using System.Collections.ObjectModel;

namespace ValueConverters
{
    /// <summary>
    /// EnumWrapperCollection is an observable collection for enums wrapped in <see cref="EnumWrapper{TEnumType}"/> type.
    /// </summary>
    /// <typeparam name="TEnum">The enum type which shall be wrapped.</typeparam>
    public class EnumWrapperCollection<TEnum> : ObservableCollection<EnumWrapper<TEnum>>
         where TEnum : struct, Enum
    {
        /// <summary>
        /// Creates an instance of the <see cref="EnumWrapperCollection{TEnum}"/> class
        /// which initializes a collection of <see cref="EnumWrapper{TEnum}"/>.
        /// </summary>
        public EnumWrapperCollection()
            : base(EnumWrapper.CreateWrappers<TEnum>())
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="EnumWrapperCollection{TEnum}"/> class.
        /// </summary>
        public EnumWrapperCollection(IEnumerable<EnumWrapper<TEnum>> enumerable) : base(enumerable)
        {
        }

        public void Refresh()
        {
            foreach (var enumWrapper in this)
            {
                enumWrapper.Refresh();
            }
        }
    }
}
