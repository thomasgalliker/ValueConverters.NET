namespace ValueConverters.Tests
{
    public class StringToDecimalConverterTests
    {
        [Fact]
        public void Convert_EmptyString_ReturnsUnsetValue()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = string.Empty;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().BeSameAs(ConverterBase.UnsetValue);
        }

        [Fact]
        public void Convert_InvalidString_ReturnsUnsetValue()
        {
            // Arrange
            IValueConverter converter = new StringToDecimalConverter();

            object input = "not a decimal";

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().BeSameAs(ConverterBase.UnsetValue);
        }

        [Fact]
        public void Convert_DecimalZero_ReturnsZeroString()
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
        public void Convert_PositiveDecimalString_ReturnsPositiveDecimal()
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
        public void Convert_NegativeDecimalString_ReturnsNegativeDecimal()
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
        public void Convert_PositiveDecimal_ReturnsPositiveString()
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
        public void Convert_NegativeDecimal_ReturnsNegativeString()
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
