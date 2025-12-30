using System;
using System.Globalization;

using FluentAssertions;
using Xunit;
using Moq;
using ValueConverters.Services;

#if (XAMARIN)
using Xamarin.Forms;
#elif (NET || NETFRAMEWORK)
using System.Windows.Data;
#endif

namespace ValueConverters.Tests
{
    public class DateTimeOffsetToStringConverterTests
    {
        private const string DefaultFormat = "g";
        private readonly Mock<ITimeZoneInfo> timeZoneInfoMock;

        public DateTimeOffsetToStringConverterTests()
        {
            var testTimeZone = TimeZoneInfo.CreateCustomTimeZone("0", TimeSpan.FromHours(1), "Test Time Zone", "Test Time Zone");
            this.timeZoneInfoMock = new Mock<ITimeZoneInfo>();
            this.timeZoneInfoMock.SetupGet(t => t.Local)
                .Returns(testTimeZone);
        }

        [Theory]
        [ClassData(typeof(DateTimeOffsetToStringConverterValidTestdata))]
        public void ShouldConvert(object ?value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter valueConverter = new DateTimeOffsetToStringConverter(this.timeZoneInfoMock.Object)
            {
                Format = DefaultFormat,
                MinValueString = "-",
            };

            // Act
            var result = valueConverter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class DateTimeOffsetToStringConverterValidTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public DateTimeOffsetToStringConverterValidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add(DateTimeOffset.MinValue, null, CultureInfo.InvariantCulture, "-");
                this.Add(new DateTimeOffset(2014, 8, 26, 18, 0, 0, TimeSpan.Zero), null, CultureInfo.InvariantCulture, "08/26/2014 19:00");
                this.Add(new DateTimeOffset(2014, 8, 26, 18, 0, 0, TimeSpan.FromHours(2)), null, CultureInfo.InvariantCulture, "08/26/2014 17:00");
            }
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter valueConverter = new DateTimeOffsetToStringConverter();
            DateTime dateTimeNow = DateTime.Now;
            string dateTimeInput = dateTimeNow.ToString("G");

            // Act
            var result = (DateTimeOffset)valueConverter.ConvertBack(dateTimeInput, null, null, null);

            // Assert
            result.Offset.Should().Be(TimeSpan.Zero);
            //(dateTimeNow - result).Should().BeLessThan(new TimeSpan(0, 0, 0, 1));
        }
    }
}
