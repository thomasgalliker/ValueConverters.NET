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
    public class DateTimeToStringConverterTests
    {
        private const string DefaultFormat = "g";
        private readonly Mock<ITimeZoneInfo> timeZoneInfoMock;

        public DateTimeToStringConverterTests()
        {
            var testTimeZone = TimeZoneInfo.CreateCustomTimeZone("0", TimeSpan.FromHours(1), "Test Time Zone", "Test Time Zone");
            this.timeZoneInfoMock = new Mock<ITimeZoneInfo>();
            this.timeZoneInfoMock.SetupGet(t => t.Local)
                .Returns(testTimeZone);
        }

        [Theory]
        [ClassData(typeof(DateTimeConverterTestsValidTestdata))]
        public void ShouldConvert(object ?value, object? parameter, CultureInfo? culture, object? expectedResult)
        {
            // Arrange
            IValueConverter valueConverter = new DateTimeToStringConverter(this.timeZoneInfoMock.Object)
            {
                Format = DefaultFormat,
                MinValueString = "-",
            };

            // Act
            var result = valueConverter.Convert(value, null, parameter, culture);

            // Assert
            result.Should().Be(expectedResult);
        }

        public class DateTimeConverterTestsValidTestdata : TheoryData<object?, object?, CultureInfo?, object?>
        {
            public DateTimeConverterTestsValidTestdata()
            {
                this.Add(null, null, CultureInfo.InvariantCulture, ConverterBase.UnsetValue);
                this.Add(DateTime.MinValue, null, CultureInfo.InvariantCulture, "-");
                this.Add(new DateTime(2014, 8, 26, 18, 0, 0, DateTimeKind.Utc), null, CultureInfo.InvariantCulture, "08/26/2014 19:00");
                this.Add(new DateTime(2014, 8, 26, 18, 0, 0, DateTimeKind.Local), null, CultureInfo.InvariantCulture, "08/26/2014 18:00");
            }
        }

        [Fact]
        public void ShouldConvertBack()
        {
            // Arrange
            IValueConverter valueConverter = new DateTimeToStringConverter();
            DateTime dateTimeNow = DateTime.Now;
            string dateTimeInput = dateTimeNow.ToString("G");

            // Act
            var result = (DateTime)valueConverter.ConvertBack(dateTimeInput, null, null, null);

            // Assert
            result.Kind.Should().Be(DateTimeKind.Utc);
            //(dateTimeNow - result).Should().BeLessThan(new TimeSpan(0, 0, 0, 1));
        }
    }
}
