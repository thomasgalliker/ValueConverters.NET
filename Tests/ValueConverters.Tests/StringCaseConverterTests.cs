using System;
using System.Globalization;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.Tests
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
                // Not a string
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);

                // To Lower Case
                this.Add(null, "l", CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("", "l", CultureInfo.InvariantCulture, "");
                this.Add("lowrider", "l", CultureInfo.InvariantCulture, "lowrider");
                this.Add("Sentence", "l", CultureInfo.InvariantCulture, "sentence");

                // To Upper Case
                this.Add(null, "u", CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("", "u", CultureInfo.InvariantCulture, "");
                this.Add("up Up UP", "u", CultureInfo.InvariantCulture, "UP UP UP");
                this.Add("Sentence", "u", CultureInfo.InvariantCulture, "SENTENCE");

                // To Title Case
#if NETSTANDARD2_0_OR_GREATER
                this.Add(null, "t", CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add("", "t", CultureInfo.InvariantCulture, "");
                this.Add("this is a sentence", "t", CultureInfo.InvariantCulture, "UP UP UP");
                this.Add("sentence", "t", CultureInfo.InvariantCulture, "SENTENCE");
#endif
            }
        }

        [Theory]
        [ClassData(typeof(StringCaseConverterInvalidTestdata))]
        public void ShouldThrowExceptionIfParameterIsInvalid(object value, object parameter, CultureInfo culture)
        {
            // Arrange
            IValueConverter converter = new StringCaseConverter();

            // Act
            Action action = () => converter.Convert(value, null, parameter, culture);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        public class StringCaseConverterInvalidTestdata : TheoryData<object, object, CultureInfo>
        {
            public StringCaseConverterInvalidTestdata()
            {
                // Invalid parameters
                this.Add("empty", "", CultureInfo.InvariantCulture);
                this.Add("null", null, CultureInfo.InvariantCulture);
            }
        }

        [Fact]
        public void ShouldThrowNotSupportedExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter converter = new StringCaseConverter();

            // Act
            Action action = () => converter.ConvertBack(null, null, null, null);

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
