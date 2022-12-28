using System;
using Xunit;

#if(XAMARIN)
using Xamarin.Forms;
#elif (NET || NETFRAMEWORK)
using System.Windows.Data;
#endif

namespace ValueConverters.Tests
{
    public class GuidToStringConverterTests
    {
        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter converter = new GuidToStringConverter { ToUpper = true };
            object input = new Guid("76B64C0B-960D-44F3-8522-E51D12884C70");
            object expectedValue = "76B64C0B-960D-44F3-8522-E51D12884C70";

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(expectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter converter = new GuidToStringConverter();
            object input = "76B64C0B-960D-44F3-8522-E51D12884C70";
            object expectedValue = new Guid("76B64C0B-960D-44F3-8522-E51D12884C70");

            // Act
            var convertedOutput = converter.ConvertBack(input, null, null, null);

            // Assert
            Assert.Equal(expectedValue, convertedOutput);
        }
    }
}
