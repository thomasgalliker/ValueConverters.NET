using System;
using System.Globalization;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.Tests
{
    public class TimeSpanToStringConverterTests
    {
        [Theory]
        [ClassData(typeof(TimeSpanToStringConverterValidTestdata))]
        public void ShouldConvert(object value, object parameter, CultureInfo culture, object expectedResult)
        {
            // Arrange
            IValueConverter converter = new TimeSpanToStringConverter
            {
                MinValueString = "-",
            };

            // Act
            var result = converter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class TimeSpanToStringConverterValidTestdata : TheoryData<object, object, CultureInfo, object>
        {
            public TimeSpanToStringConverterValidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add(TimeSpan.MinValue, null, CultureInfo.InvariantCulture, "-");
                this.Add(TimeSpan.Zero, null, CultureInfo.InvariantCulture, "0:00:00");
                this.Add(new TimeSpan(00, 00, 00, 00, 5), null, CultureInfo.InvariantCulture, "0:00:00.005");
                this.Add(new TimeSpan(00, 00, 00, 04, 5), null, CultureInfo.InvariantCulture, "0:00:04.005");
                this.Add(new TimeSpan(00, 00, 03, 04, 5), null, CultureInfo.InvariantCulture, "0:03:04.005");
                this.Add(new TimeSpan(00, 02, 03, 04, 5), null, CultureInfo.InvariantCulture, "2:03:04.005");
                this.Add(new TimeSpan(01, 02, 03, 04, 5), null, CultureInfo.InvariantCulture, "1:2:03:04.005");
                this.Add(TimeSpan.MaxValue, null, CultureInfo.InvariantCulture, "10675199:2:48:05.4775807");
            }
        }
    }
}
