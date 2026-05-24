namespace ValueConverters.Tests
{
    public class IsEmptyConverterTests
    {
        [Fact]
        public void Convert_NonEmptyString_ReturnsFalse()
        {
            // Arrange
            IValueConverter converter = new IsEmptyConverter { IsInverted = false };

            const string Input = "test";
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(Input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void Convert_EmptyString_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = new IsEmptyConverter { IsInverted = false };

            var input = string.Empty;
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void Convert_NullString_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = new IsEmptyConverter { IsInverted = false };

            const string? Input = null;
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(Input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void Convert_NonEmptyEnumerable_ReturnsFalse()
        {
            // Arrange
            IValueConverter converter = new IsEmptyConverter { IsInverted = false };

            var input = new List<string> { "Pi", "pa", "po" };
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void Convert_NonEmptyEnumerableWithInversion_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = new IsEmptyConverter { IsInverted = true };

            var input = new List<string> { "Pi", "pa", "po" };
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ConvertBack_AnyValue_ThrowsNotSupportedException()
        {
            // Arrange
            IValueConverter converter = new IsEmptyConverter();
            object input = false;

            // Act
            Action action = () => converter.ConvertBack(input, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
