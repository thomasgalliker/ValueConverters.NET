
using System.Windows.Data;

using Xunit;
using Xunit.Abstractions;

namespace ValueConverters.NetFx.Tests
{
    public class DebugConverterTests
    {
        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter converter = new DebugConverter();
            object input = true;
            object expectedValue = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(convertedOutput, expectedValue);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter converter = new DebugConverter();
            object input = false;
            object expectedValue = false;

            // Act
            var convertedOutput = converter.ConvertBack(input, null, null, null);

            // Assert
            Assert.Equal(convertedOutput, expectedValue);
        }
    }
}
