namespace ValueConverters.Tests
{
    public class ValueToBoolConverterTests
    {
        [Fact]
        public void Convert_MatchingValue_ReturnsTrue()
        {
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int> { TrueValue = TrueValue };

            var result = converter.Convert(TrueValue, null, null, null);

            result.Should().Be(true);
        }

        [Fact]
        public void Convert_DifferentValue_ReturnsFalse()
        {
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int> { TrueValue = TrueValue };
            const int Input = TrueValue + 1;

            var result = converter.Convert(Input, null, null, null);

            result.Should().Be(false);
        }

        [Fact]
        public void Convert_NullTrueValue_ReturnsTrue()
        {
            const object? TrueValue = null;
            IValueConverter converter = new ValueToBoolConverter<object> { TrueValue = TrueValue };

            var result = converter.Convert(TrueValue, null, null, null);

            result.Should().Be(true);
        }

        [Fact]
        public void ConvertBack_TrueValue_ReturnsConfiguredTrueValue()
        {
            const int TrueValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int?> { TrueValue = TrueValue };

            var result = converter.ConvertBack(true, typeof(int?), null, null);

            result.Should().Be(TrueValue);
        }

        [Fact]
        public void ConvertBack_FalseValue_ReturnsConfiguredFalseValue()
        {
            const int FalseValue = 42;
            IValueConverter converter = new ValueToBoolConverter<int?> { FalseValue = FalseValue };

            var result = converter.ConvertBack(false, typeof(int?), null, null);

            result.Should().Be(FalseValue);
        }

        [Fact]
        public void ConvertBack_FalseValueWithNullableTarget_ReturnsNull()
        {
            IValueConverter converter = new ValueToBoolConverter<int?>();

            var result = converter.ConvertBack(false, typeof(int?), null, null);

            result.Should().Be(null);
        }

        [Fact]
        public void ConvertBack_InvertedFalseValue_ReturnsConfiguredTrueValue()
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
        public void Convert_BaseOnFalseValue_ReturnsTrue()
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
