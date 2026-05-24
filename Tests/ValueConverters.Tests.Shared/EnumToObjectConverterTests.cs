namespace ValueConverters.Tests
{
    public class EnumToObjectConverterTests
    {
        [Fact]
        public void Convert_MatchingResourceKey_ReturnsResourceValue()
        {
            // Arrange
            string key1 = TestEnum.Lorem.ToString();
            const string Value1 = "value 1";
            string key2 = TestEnum.Ipsum.ToString();
            const string Value2 = "value 2";
            string key3 = TestEnum.Dolor.ToString();
            const string Value3 = "value 3";

            IValueConverter enumToObjectConverter = new EnumToObjectConverter
            {
                Items = new ResourceDictionary
                {
                    { key1, Value1 },
                    { key2, Value2 },
                    { key3, Value3 },
                }
            };

            const TestEnum InutValue = TestEnum.Ipsum;

            // Act
            var convertedOutput = enumToObjectConverter.Convert(InutValue, null, null, null);

            // Assert
            convertedOutput.Should().Be(Value2);
        }

        [Fact]
        public void Convert_MissingResourceKey_ReturnsUnsetValue()
        {
            // Arrange
            string key1 = TestEnum.Lorem.ToString();
            const string Value1 = "value 1";
            string key3 = TestEnum.Dolor.ToString();
            const string Value3 = "value 3";

            IValueConverter enumToObjectConverter = new EnumToObjectConverter
            {
                Items = new ResourceDictionary
                {
                    { key1, Value1 },
                    { key3, Value3 },
                }
            };

            const TestEnum InutValue = TestEnum.Ipsum;

            // Act
            var convertedOutput = enumToObjectConverter.Convert(InutValue, null, null, null);

            // Assert
            Assert.Equal(ConverterBase.UnsetValue, convertedOutput);
        }

        [Fact]
        public void Convert_EmptyResourceDictionary_ReturnsUnsetValue()
        {
            // Arrange
            IValueConverter enumToObjectConverter = new EnumToObjectConverter();

            const TestEnum InutValue = TestEnum.Ipsum;

            // Act
            var convertedOutput = enumToObjectConverter.Convert(InutValue, null, null, null);

            // Assert
            Assert.Equal(ConverterBase.UnsetValue, convertedOutput);
        }

        [Fact]
        public void ConvertBack_AnyValue_ThrowsNotSupportedException()
        {
            // Arrange
            IValueConverter enumToObjectConverter = new EnumToObjectConverter();

            const TestEnum InutValue = TestEnum.Ipsum;

            // Act
            Action action = () => enumToObjectConverter.ConvertBack(InutValue, null, null, null);

            // Assert
            Assert.Throws<NotSupportedException>(action);
        }
    }
}
