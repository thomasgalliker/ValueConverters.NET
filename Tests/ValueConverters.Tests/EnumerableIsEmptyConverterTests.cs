
using System;
using System.Collections.Generic;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class EnumerableIsEmptyConverterTests
    {
        [Fact]
        public void ShouldConvertStringToIsEmptyBool()
        {
            // Arrange
            IValueConverter converter = new EnumerableIsEmptyConverter { IsInverted = false };

            const string Input = "test";
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(Input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertEmptyStringToIsEmptyBool()
        {
            // Arrange
            IValueConverter converter = new EnumerableIsEmptyConverter { IsInverted = false };

            var input = string.Empty;
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertNullStringToIsEmptyBool()
        {
            // Arrange
            IValueConverter converter = new EnumerableIsEmptyConverter { IsInverted = false };

            const string Input = null;
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(Input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertIEnumerableToIsEmptyBool()
        {
            // Arrange
            IValueConverter converter = new EnumerableIsEmptyConverter { IsInverted = false };

            var input = new List<string> { "Pi", "pa", "po" };
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertIEnumerableToIsEmptyBoolInverted()
        {
            // Arrange
            IValueConverter converter = new EnumerableIsEmptyConverter { IsInverted = true };

            var input = new List<string> { "Pi", "pa", "po" };
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertBackIEnumerableToIsEmptyBool()
        {
            // Arrange
            IValueConverter converter = new EnumerableIsEmptyConverter();
            object input = false;

            // Act
            Action action = () => converter.ConvertBack(input, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
