using System.Windows;
using System.Windows.Data;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class VisibilityInverterTests
    {
        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter converter = new VisibilityInverter();
            object input = Visibility.Visible;
            const Visibility ExpectedValue = Visibility.Collapsed;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter converter = new VisibilityInverter();
            object input = Visibility.Collapsed;
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.ConvertBack(input, null, null, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }
    }
}