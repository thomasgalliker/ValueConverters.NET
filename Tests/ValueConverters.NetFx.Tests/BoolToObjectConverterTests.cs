using System;
using System.Windows.Data;
using FluentAssertions;
using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class BoolToObjectConverterTests
    {
        [Fact]
        public void ShouldConvertTrueValue()
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
        public void ShouldConvertFalseValue()
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
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter boolToObjectConverter = new BoolToObjectConverter();

            const string InutValue = "value";

            // Act
            Action action = () => boolToObjectConverter.ConvertBack(InutValue, null, null, null);

            // Assert
            Assert.Throws<NotSupportedException>(action);
        }
    }
}
