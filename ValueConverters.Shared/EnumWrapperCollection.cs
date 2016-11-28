using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ValueConverters
{
    /// <summary>
    /// EnumWrapperCollection is an observable collection for enums wrapped in <see cref="EnumWrapper{TEnumType}"/> type.
    /// </summary>
    /// <typeparam name="TEnumType">Enum type which shall be wrapped.</typeparam>
    public class EnumWrapperCollection<TEnumType> : ObservableCollection<EnumWrapper<TEnumType>>
    {
        /// <summary>
        /// Creates an instance of the <see cref="EnumWrapperCollection{TEnumType}"/> class
        /// which initializes a collection of <see cref="EnumWrapper{TEnumType}"/>.
        /// </summary>
        public EnumWrapperCollection() : base(EnumWrapper.CreateWrappers<TEnumType>())
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="EnumWrapperCollection{TEnumType}"/> class.
        /// </summary>
        public EnumWrapperCollection(IEnumerable<EnumWrapper<TEnumType>> enumerable) : base(enumerable)
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
