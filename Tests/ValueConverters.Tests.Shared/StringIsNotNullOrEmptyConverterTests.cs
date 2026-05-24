namespace ValueConverters.Tests
{
    public class StringIsNotNullOrEmptyConverterTests
    {
        [Fact]
        public void Convert_EmptyString_ReturnsFalse()
        {
            // Arrange
            IValueConverter converter = new StringIsNotNullOrEmptyConverter();

            bool ExpectedValue = false;
            object input = string.Empty;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(ExpectedValue);
        }

        [Fact]
        public void Convert_NonEmptyString_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = new StringIsNotNullOrEmptyConverter();

            bool ExpectedValue = true;
            object input = "test";

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(ExpectedValue);
        }

        [Fact]
        public void ConvertBack_AnyValue_ThrowsNotSupportedException()
        {
            // Arrange
            IValueConverter converter = new StringIsNotNullOrEmptyConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
