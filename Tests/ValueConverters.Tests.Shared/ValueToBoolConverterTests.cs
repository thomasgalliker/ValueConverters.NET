namespace ValueConverters.Tests
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
            const object? TrueValue = null;
            IValueConverter converter = new ValueToBoolConverter<object> { TrueValue = TrueValue };

            var result = converter.Convert(TrueValue, null, null, null);

            result.Should().Be(true);
        }

        [Fact]
        public void ShouldConvertTrueBack()
        {
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int?> { TrueValue = TrueValue };

            var result = converter.ConvertBack(true, typeof(int?), null, null);

            result.Should().Be(TrueValue);
        }

        [Fact]
        public void ShouldConvertFalseBack()
        {
            const int FalseValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int?> { FalseValue = FalseValue };

            var result = converter.ConvertBack(false, typeof(int?), null, null);

            result.Should().Be(FalseValue);
        }

        [Fact]
        public void ShouldConvertFalseBackToNull()
        {
            IValueConverter converter = new ValueToBoolConverter<int?>();

            var result = converter.ConvertBack(false, typeof(int?), null, null);

            result.Should().Be(null);
        }

        [Fact]
        public void ShouldUseIsInvertedWhenConvertingBack()
        {
            const int FalseValue = -42;
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int?>
            {
                FalseValue = FalseValue,
                TrueValue = TrueValue,
                IsInverted = true,
            };

            var result = converter.ConvertBack(false, typeof(int?), null, null);

            result.Should().Be(TrueValue);
        }

        [Fact]
        public void ShouldUseBaseWhenConverting()
        {
            const int TrueValue = 42;
            const int FalseValue = 0;
            IValueConverter converter = new ValueToBoolConverter<int>
            {
                TrueValue = TrueValue,
                FalseValue = FalseValue,
                BaseOnFalseValue = true,
            };
            const int Input = TrueValue + 1;

            var result = converter.Convert(Input, null, null, null);

            result.Should().Be(true);

        }
    }
}
