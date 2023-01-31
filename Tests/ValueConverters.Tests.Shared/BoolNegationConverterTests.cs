﻿using Xunit;

#if(XAMARIN)
using Xamarin.Forms;
#elif (NET || NETFRAMEWORK)
using System.Windows.Data;
#endif

namespace ValueConverters.Tests
{
    public class BoolNegationConverterTests
    {
        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter converter = new BoolNegationConverter();
            object input = true;
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter converter = new BoolNegationConverter();
            object input = false;
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.ConvertBack(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }
    }
}
