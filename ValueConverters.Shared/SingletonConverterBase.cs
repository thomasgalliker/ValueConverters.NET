namespace ValueConverters
{
    public abstract class SingletonConverterBase<TConverter> : ConverterBase
        where TConverter : new()
    {
        private static readonly Lazy<TConverter> InstanceConstructor = new Lazy<TConverter>(() =>
        {
            return new TConverter();
        }, LazyThreadSafetyMode.PublicationOnly);

        public static TConverter Instance => InstanceConstructor.Value;
    }
}