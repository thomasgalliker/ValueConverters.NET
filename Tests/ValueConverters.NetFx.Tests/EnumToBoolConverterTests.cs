using System.Windows.Data;

using ValueConverters.NetFx.Tests.TestData;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class EnumToBoolConverterTests
    {
        [Fact]
        public void ShouldConvertToTrueValue()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            const TestEnum Input = TestEnum.Lorem;
            string inputParameter = TestEnum.Lorem.ToString();
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(Input, null, inputParameter, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertToFalseValue()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            const TestEnum Input = TestEnum.Lorem;
            string inputParameter = TestEnum.Ipsum.ToString();
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(Input, null, inputParameter, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            string input = TestEnum.Lorem.ToString();
            const TestEnum ExpectedValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.ConvertBack(null, typeof(TestEnum), input, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }
    }
}