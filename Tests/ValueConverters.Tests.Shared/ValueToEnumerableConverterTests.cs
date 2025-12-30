namespace ValueConverters.Tests
{
    public class ValueToEnumerableConverterTests
    {
        [Theory]
        [ClassData(typeof(ValueToEnumerableConverterTestdata))]
        public void ShouldConvert(object? value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter converter = new ValueToEnumerableConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        public class ValueToEnumerableConverterTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public ValueToEnumerableConverterTestdata()
            {
                // Input is null
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);

                // Input is not null
                this.Add("test string", null, CultureInfo.InvariantCulture, new object[] { "test string" });
            }
        }

        [Fact]
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter converter = new ValueToEnumerableConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
