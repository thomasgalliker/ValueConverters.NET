﻿using System;
using FluentAssertions;
using Xunit;

#if(XAMARIN)
using Xamarin.Forms;
#elif (NET || NETFRAMEWORK)
using System.Windows.Data;
#endif

namespace ValueConverters.Tests
{
    public class StringIsNotNullOrEmptyConverterTests
    {
        [Fact]
        public void ShouldConvertEmptyStringToFalse()
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
        public void ShouldConvertStringToTrue()
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
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
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
