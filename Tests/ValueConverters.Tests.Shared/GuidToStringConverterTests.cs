namespace ValueConverters.Tests
{
    public class GuidToStringConverterTests
    {
        [Fact]
        public void Convert_GuidValue_ReturnsString()
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
        public void ConvertBack_GuidString_ReturnsGuid()
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
