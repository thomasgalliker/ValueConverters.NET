namespace ValueConverters.Tests
{
    public class EnumToBoolConverterTests
    {
        [Fact]
        public void Convert_MatchingEnumParameter_ReturnsTrue()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            const TestEnum Input = TestEnum.Lorem;
            var inputParameter = nameof(TestEnum.Lorem);
            const bool ExpectedValue = true;

            // Act
            var convertedOutput = converter.Convert(Input, null, inputParameter, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void Convert_DifferentEnumParameter_ReturnsFalse()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            const TestEnum Input = TestEnum.Lorem;
            var inputParameter = nameof(TestEnum.Ipsum);
            const bool ExpectedValue = false;

            // Act
            var convertedOutput = converter.Convert(Input, null, inputParameter, null);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Fact]
        public void ConvertBack_TrueValue_ReturnsEnumValue()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            const bool InputValue = true;
            var input = nameof(TestEnum.Lorem);
            const TestEnum ExpectedValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.ConvertBack(InputValue, typeof(TestEnum), input, CultureInfo.CurrentUICulture);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(null)]
        public void ConvertBack_ValueIsNotTrue_ReturnsBindingDoNothing(bool? inputValue)
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            var input = nameof(TestEnum.Lorem);

            // Act
            var convertedOutput = converter.ConvertBack(inputValue, typeof(TestEnum), input, CultureInfo.CurrentUICulture);

            // Assert
            convertedOutput.Should().BeSameAs(Binding.DoNothing);
        }

        [Fact]
        public void ConvertBack_ValueIsNotBoolean_ReturnsBindingDoNothing()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            var input = nameof(TestEnum.Lorem);

            // Act
            var convertedOutput = converter.ConvertBack("true", typeof(TestEnum), input, CultureInfo.CurrentUICulture);

            // Assert
            convertedOutput.Should().BeSameAs(Binding.DoNothing);
        }

        [Fact]
        public void ConvertBack_MissingParameter_ReturnsBindingDoNothing()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();

            // Act
            var convertedOutput = converter.ConvertBack(true, typeof(TestEnum), null, CultureInfo.CurrentUICulture);

            // Assert
            convertedOutput.Should().BeSameAs(Binding.DoNothing);
        }

        [Fact]
        public void ConvertBack_TrueValueWithNullableEnumTarget_ReturnsEnumValue()
        {
            // Arrange
            IValueConverter converter = new EnumToBoolConverter();
            var input = nameof(TestEnum.Lorem);
            const TestEnum ExpectedValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.ConvertBack(true, typeof(TestEnum?), input, CultureInfo.CurrentUICulture);

            // Assert
            Assert.Equal(ExpectedValue, convertedOutput);
        }
    }
}
