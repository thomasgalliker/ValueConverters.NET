using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class ValueToBoolConverterTests
    {
        [Fact]
        public void ShouldConvertTrue()
        {
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int> { TrueValue = TrueValue };

            var result = converter.Convert(TrueValue, null, null, null);

            result.Should().Be(true);
        }

        [Fact]
        public void ShouldConvertFalse()
        {
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int> { TrueValue = TrueValue };
            const int Input = TrueValue + 1;

            var result = converter.Convert(Input, null, null, null);

            result.Should().Be(false);
        }

        [Fact]
        public void ShouldConvertNull()
        {
            const object TrueValue = null;
            IValueConverter converter = new ValueToBoolConverter<object> { TrueValue = TrueValue };

            var result = converter.Convert(TrueValue, null, null, null);

            result.Should().Be(true);
        }
    }
}