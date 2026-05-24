namespace ValueConverters.Tests
{
    public class DebugConverterTests
    {
        [Fact]
        public void Convert_Value_ReturnsSameValue()
        {
            // Arrange
            IValueConverter converter = new DebugConverter();
            object input = true;
            object expectedValue = true;

            // Act
            var convertedOutput = converter.Convert(input, null, null, null);

            // Assert
            Assert.Equal(expectedValue, convertedOutput);
        }

        [Fact]
        public void ConvertBack_Value_ReturnsSameValue()
        {
            // Arrange
            IValueConverter converter = new DebugConverter();
            object input = false;
            object expectedValue = false;

            // Act
            var convertedOutput = converter.ConvertBack(input, null, null, null);

            // Assert
            Assert.Equal(expectedValue, convertedOutput);
        }
    }
}
