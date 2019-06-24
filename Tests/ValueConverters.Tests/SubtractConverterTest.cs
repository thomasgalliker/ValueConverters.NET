using System.Globalization;
using System.Windows.Data;
using FluentAssertions;
using Xunit;

namespace ValueConverters.Tests
{
    public class SubtractConverterTest
    {
        [Fact]
        public void SubtractDoubleIntputTest()
        {
            // arrange
            IValueConverter sut = new SubtractConverter();

            // act
            var result = sut.Convert(4.444, null, 1.111, null);

            // assert
            result.Should().Be(3.333);
        }

        [Fact]
        public void SubtractInvalidIntputTest()
        {
            // arrange
            IValueConverter sut = new SubtractConverter();

            // act & assert
            sut.Convert("foo", null, null, null).Should().Be("foo");
            sut.Convert(4.444, null, null, null).Should().Be(4.444);
            sut.Convert(4.444, null, "foo", null).Should().Be(4.444);
        }

        [Fact]
        public void SubtractStringIntputTest()
        {
            // arrange
            IValueConverter sut = new SubtractConverter();

            // act & assert
            sut.Convert("4,444", null, "1,111", new CultureInfo("de-de")).Should().Be(3.333);
            sut.Convert("4.444", null, "1.111", new CultureInfo("en-us")).Should().Be(3.333);
        }
    }
}
