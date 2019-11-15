using System;
using System.Globalization;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class StringCaseConverterTests
    {
        [Theory]
        [ClassData(typeof(StringCaseConverterValidTestdata))]
        public void ShouldConvert(object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new StringCaseConverter();

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class StringCaseConverterValidTestdata : TheoryData<object, object, CultureInfo, object>
        {
            public StringCaseConverterValidTestdata()
            {
                // No Parameter
                this.Add(null, null, CultureInfo.InvariantCulture, "");
                this.Add("", "", CultureInfo.InvariantCulture, "");
                this.Add("lowrider", null, CultureInfo.InvariantCulture, "lowrider");
                this.Add("Sentence", null, CultureInfo.InvariantCulture, "Sentence");

                // To Lower Case
                this.Add(null, "l", CultureInfo.InvariantCulture, "");
                this.Add("", "l", CultureInfo.InvariantCulture, "");
                this.Add("lowrider", "l", CultureInfo.InvariantCulture, "lowrider");
                this.Add("Sentence", "l", CultureInfo.InvariantCulture, "sentence");

                // To Upper Case
                this.Add(null, "u", CultureInfo.InvariantCulture, "");
                this.Add("", "u", CultureInfo.InvariantCulture, "");
                this.Add("up Up UP", "u", CultureInfo.InvariantCulture, "UP UP UP");
                this.Add("Sentence", "u", CultureInfo.InvariantCulture, "SENTENCE");
            }
        }

        [Fact]
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter converter = new StringCaseConverter();

            const bool InutValue = true;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
