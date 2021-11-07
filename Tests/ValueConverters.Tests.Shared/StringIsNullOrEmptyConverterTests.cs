using System;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.Tests
{
    public class StringIsNullOrEmptyConverterTests
    {
        [Fact]
        public void ShouldConvertEmptyStringToFalse()
        {
            // Arrange
            IValueConverter converter = new StringIsNullOrEmptyConverter();

            // Act & assert
            converter.Convert(string.Empty, null, null, null).Should().Be(true);
            converter.Convert(null, null, null, null).Should().Be(true);
        }

        [Fact]
        public void ShouldConvertStringToFalse()
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
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
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
