namespace ValueConverters.Tests
{
    public class VersionToStringConverterTests
    {
        [Fact]
        public void Convert_VersionValue_ReturnsString()
        {
            // Arrange
            IValueConverter converter = new VersionToStringConverter();
            var version = new Version("1.2.3.4");

            // Act
            var convertedOutput = converter.Convert(version, null, null, null);

            // Assert
            convertedOutput.Should().Be("1.2.3.4");
        }

        [Fact]
        public void Convert_FieldCountParameter_ReturnsTruncatedString()
        {
            // Arrange
            IValueConverter converter = new VersionToStringConverter();
            var version = new Version("1.2.3.4");
            var fieldCount = "2";

            // Act
            var convertedOutput = converter.Convert(version, null, fieldCount, null);

            // Assert
            convertedOutput.Should().Be("1.2");
        }
    }
}
