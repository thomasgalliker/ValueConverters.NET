namespace ValueConverters
{
    internal static class PropertyHelper
    {
        public static Property Create<T, TParent>(string name, T? defaultValue) =>
#if MAUI
            Property.Create(name, typeof(T), typeof(TParent), defaultValue);
#else
            Property.Register(name, typeof(T), typeof(TParent), new PropertyMetadata(defaultValue));
#endif

        public static Property Create<T, TParent>(string name) => Create<T, TParent>(name, default);
    }
}
