namespace ValueConverters.Tests
{
    public class MinMaxValueToBoolConverterTests
    {
        [Theory]
        [ClassData(typeof(MinMaxValueToBoolConverterValidTestdata))]
        public void ShouldConvert(object? value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter valueConverter = new MinMaxValueToBoolConverter
            {
                MinValue = 20,
                MaxValue = 80,
            };

            // Act
            var result = valueConverter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class MinMaxValueToBoolConverterValidTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public MinMaxValueToBoolConverterValidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add(0, null, CultureInfo.InvariantCulture, false);
                this.Add(20, null, CultureInfo.InvariantCulture, true);
                this.Add(50, null, CultureInfo.InvariantCulture, true);
                this.Add(80, null, CultureInfo.InvariantCulture, true);
                this.Add(100, null, CultureInfo.InvariantCulture, false);
            }
        }

        [Fact]
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter valueConverter = new MinMaxValueToBoolConverter();

            // Act
            Action action = () => valueConverter.ConvertBack(null, null, null, null);

            // Assert
            Assert.Throws<NotSupportedException>(action);
        }
    }
}
