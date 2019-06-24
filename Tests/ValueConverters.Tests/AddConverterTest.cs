using System.Globalization;
using System.Windows.Data;
using FluentAssertions;
using Xunit;

namespace ValueConverters.Tests
{
    public class AddConverterTest
    {
        [Fact]
        public void AddDoubleIntputTest()
        {
            // arrange
            IValueConverter sut = new AddConverter();

            // act
            var result = sut.Convert(4.444, null, 1.111, null);

            // assert
            result.Should().Be(5.555);
        }

        [Fact]
        public void AddInvalidIntputTest()
        {
            // arrange
            IValueConverter sut = new AddConverter();

            // act & assert
            sut.Convert("foo", null, null, null).Should().Be("foo");
            sut.Convert(4.444, null, null, null).Should().Be(4.444);
            sut.Convert(4.444, null, "foo", null).Should().Be(4.444);
        }

        [Fact]
        public void AddStringIntputTest()
        {
            // arrange
            IValueConverter sut = new AddConverter();

            // act & assert
            sut.Convert("4,444", null, "1,111", new CultureInfo("de-de")).Should().Be(5.555);
            sut.Convert("4.444", null, "1.111", new CultureInfo("en-us")).Should().Be(5.555);
        }
    }
}
