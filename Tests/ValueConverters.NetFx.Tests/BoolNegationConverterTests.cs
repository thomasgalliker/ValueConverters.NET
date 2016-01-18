
using System.Windows.Data;

using Xunit;

namespace ValueConverters.NetFx.Tests
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
            Assert.Equal(convertedOutput, ExpectedValue);
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
            Assert.Equal(convertedOutput, ExpectedValue);
        }
    }
}
