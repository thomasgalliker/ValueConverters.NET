namespace ValueConverters.Tests
{
    public class BoolToObjectConverterTests
    {
        [Fact]
        public void ShouldConvert_ReturnsTrue()
        {
            // Arrange
            const string Value1 = "value 1";
            const string Value2 = "value 2";

            IValueConverter boolToObjectConverter = new BoolToObjectConverter
            {
                TrueValue = Value1,
                FalseValue = Value2
            };

            const bool InutValue = true;

            // Act
            var convertedOutput = boolToObjectConverter.Convert(InutValue, null, null, null);

            // Assert
            convertedOutput.Should().Be(Value1);
        }

        [Fact]
        public void ShouldConvert_ReturnsFalse()
        {
            // Arrange
            const string Value1 = "value 1";
            const string Value2 = "value 2";

            IValueConverter boolToObjectConverter = new BoolToObjectConverter
            {
                TrueValue = Value1,
                FalseValue = Value2
            };

            const bool InutValue = false;

            // Act
            var convertedOutput = boolToObjectConverter.Convert(InutValue, null, null, null);

            // Assert
            convertedOutput.Should().Be(Value2);
        }

        [Fact]
        public void ShouldConvertBack_ReturnsTrue()
        {
            // Arrange
            const string Value1 = "value 1";
            const string Value2 = "value 2";

            IValueConverter boolToObjectConverter = new BoolToObjectConverter
            {
                TrueValue = Value1,
                FalseValue = Value2
            };

            // Act
            var convertedOutput = boolToObjectConverter.ConvertBack(Value1, null, null, null);

            // Assert
            convertedOutput.Should().Be(true);
        }

        [Fact]
        public void ShouldConvertBack_ReturnsFalse()
        {
            // Arrange
            const string Value1 = "value 1";
            const string Value2 = "value 2";

            IValueConverter boolToObjectConverter = new BoolToObjectConverter
            {
                TrueValue = Value1,
                FalseValue = Value2
            };

            // Act
            var convertedOutput = boolToObjectConverter.ConvertBack(Value2, null, null, null);

            // Assert
            convertedOutput.Should().Be(false);
        }
    }
}
