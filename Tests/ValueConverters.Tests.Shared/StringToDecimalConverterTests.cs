namespace ValueConverters.Tests
{
    public class StringToDecimalConverterTests
    {
        [Fact]
        public void ShouldConvertEmptyStringToDecimalZero()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = string.Empty;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(0m);
        }

        [Fact]
        public void ShouldConvertDecimalZeroToZeroString()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = 0m;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be("0");
        }

        [Fact]
        public void ShouldConvertStringToPositiveDecimal()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = "123.1100";

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(123.11m);
        }

        [Fact]
        public void ShouldConvertStringToNegativeDecimal()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = decimal.MinValue.ToString("G");

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(decimal.MinValue);
        }

        [Fact]
        public void ShouldConvertDecimalToPositiveString()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = 123.1100m;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be("123.1100");
        }

        [Fact]
        public void ShouldConvertDecimalToNegativeString()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = decimal.MinValue;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(decimal.MinValue.ToString("G"));
        }
    }
}
