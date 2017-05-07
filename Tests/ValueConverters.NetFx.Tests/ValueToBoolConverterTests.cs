using System.Windows.Data;

using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class ValueToBoolConverterTests
    {
        [Fact]
        public void ShouldConvertTrue()
        {
            const int trueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int> {TrueValue = trueValue};

            object result = converter.Convert(trueValue, null, null, null);

            Assert.True((bool)result);
        }

        [Fact]
        public void ShouldConvertFalse()
        {
            const int trueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int> { TrueValue = trueValue };
            const int input = trueValue + 1;

            object result = converter.Convert(input, null, null, null);

            Assert.False((bool)result);
        }

        [Fact]
        public void ShouldConvertNull()
        {
            const object trueValue = null;
            IValueConverter converter = new ValueToBoolConverter<object> {TrueValue = trueValue};

            object result = converter.Convert(trueValue, null, null, null);

            Assert.True((bool)result);
        }
    }
}
