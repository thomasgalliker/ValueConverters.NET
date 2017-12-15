using System;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class StringLengthToBoolConverterTests
    {
        [Fact]
        public void ShouldConvertEmptyStringToFalse()
        {
            // Arrange
            IValueConverter converter = new StringLengthToBoolConverter();

            bool ExpectedValue = false;
            object input = string.Empty;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            convertedOutput.Should().Be(ExpectedValue);
        }

        public void ShouldConvertStringToTrue()
        {
            // Arrange
            IValueConverter converter = new StringLengthToBoolConverter();

            bool ExpectedValue = true;
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
            IValueConverter converter = new StringLengthToBoolConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            Assert.Throws<NotSupportedException>(action);
        }
    }
}
