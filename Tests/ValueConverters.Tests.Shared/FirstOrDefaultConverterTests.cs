namespace ValueConverters.Tests
{
    public class FirstOrDefaultConverterTests
    {
        [Theory]
        [ClassData(typeof(FirstOrDefaultConverterTestdata))]
        public void Convert_Value_ReturnsFirstItemOrUnsetValue(object? value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter converter = new FirstOrDefaultConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class FirstOrDefaultConverterTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public FirstOrDefaultConverterTestdata()
            {
                // Input is not IEnumerable
                this.Add(0, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);

                // Input is an empty IEnumerable
                this.Add(new object[] { }, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);

                // Input is an array
                this.Add(new[] { 1, 2, 3 }, null, CultureInfo.InvariantCulture, 1);
            }
        }

        [Fact]
        public void ConvertBack_AnyValue_ThrowsNotSupportedException()
        {
            // Arrange
            IValueConverter converter = new FirstOrDefaultConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
