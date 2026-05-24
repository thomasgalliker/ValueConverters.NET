namespace ValueConverters.Tests
{
    public class StringIsNullOrEmptyConverterTests
    {
        [Fact]
        public void Convert_EmptyStringOrNull_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = new StringIsNullOrEmptyConverter();

            // Act & assert
            converter.Convert(string.Empty, null, null, null).Should().Be(true);
            converter.Convert(null, null, null, null).Should().Be(true);
        }

        [Fact]
        public void Convert_NonEmptyString_ReturnsFalse()
        {
            // Arrange
            IValueConverter converter = new StringIsNullOrEmptyConverter();

            bool ExpectedValue = false;
            object input = "test";

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(ExpectedValue);
        }

        [Fact]
        public void Convert_InstanceWithEmptyString_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = StringIsNullOrEmptyConverter.Instance;

            // Act
            var convertedOutput = converter.Convert(string.Empty, null, null, null);

            // Assert
            convertedOutput.Should().Be(true);
        }

        [Fact]
        public void ConvertBack_AnyValue_ThrowsNotSupportedException()
        {
            // Arrange
            IValueConverter converter = new StringIsNullOrEmptyConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
