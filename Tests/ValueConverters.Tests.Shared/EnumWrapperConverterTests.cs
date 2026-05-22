namespace ValueConverters.Tests
{
    public class EnumWrapperConverterTests
    {
        [Fact]
        public void Convert_EnumValue_ReturnsLocalizedEnumWrapper()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InputValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.Convert(InputValue, null, null, null);

            // Assert
            convertedOutput.ToString().Should().Be(AppResources.LoremText);
        }

        [Fact]
        public void Convert_MissingDisplayNameResource_ThrowsInvalidOperationException()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InputValue = TestEnum.Ipsum;

            // Act
            var convertedOutput = converter.Convert(InputValue, null, null, null);
            Action action = () => convertedOutput.ToString();

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Convert_EnumWithoutAnnotation_ReturnsEnumName()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InputValue = TestEnum.Dolor;
            string expectedOutput = InputValue.ToString();

            // Act
            var convertedOutput = converter.Convert(InputValue, null, null, null);

            // Assert
            convertedOutput.ToString().Should().Be(expectedOutput);
        }

        [Fact]
        public void Convert_GenericEnumerable_ReturnsEnumWrapperEnumerable()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = Enum.GetValues(typeof(TestEnum)).OfType<TestEnum>();

            // Act
            var convertedOutput = (IEnumerable<EnumWrapper<TestEnum>>)converter.Convert(inutValue, null, null, null);

            // Assert
            convertedOutput.Should().HaveCount(inutValue.Count());
        }

        [Fact]
        public void ConvertBack_EnumValue_ReturnsEnumValue()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            const TestEnum InputValue = TestEnum.Lorem;

            // Act
            var convertedOutput = (TestEnum)converter.ConvertBack(InputValue, typeof(TestEnum), null, null);

            // Assert
            convertedOutput.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void CreateMapper_LongName_ReturnsEnumWrapperWithLongName()
        {
            // Arrange
            var converter = new EnumWrapperConverter();

            const TestEnum InputValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.CreateMapper<TestEnum>(InputValue);

            // Assert
            convertedOutput.Value.Should().Be(TestEnum.Lorem);
            convertedOutput.LocalizedValue.Should().Be("Lorem text");
        }

        [Fact]
        public void CreateMapper_ShortName_ReturnsEnumWrapperWithShortName()
        {
            // Arrange
            var converter = new EnumWrapperConverter { NameStyle = EnumWrapperConverterNameStyle.LongName };

            const TestEnum InputValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.CreateMapper<TestEnum>(InputValue, EnumWrapperConverterNameStyle.ShortName);

            // Assert
            convertedOutput.Value.Should().Be(TestEnum.Lorem);
            convertedOutput.LocalizedValue.Should().Be("Lorem (short)");
        }

        [Fact]
        public void ConvertBack_EnumWrapperWithEnumTarget_ReturnsEnumValue()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var convertedOutput = (TestEnum)converter.ConvertBack(inutValue, typeof(TestEnum), null, null);

            // Assert
            convertedOutput.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void ConvertBack_EnumWrapperWithNullableEnumTarget_ReturnsEnumValue()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var convertedOutput = (TestEnum?)converter.ConvertBack(inutValue, typeof(TestEnum?), null, null);

            // Assert
            convertedOutput.Should().NotBeNull();
            convertedOutput.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void ConvertBack_EnumWrapperWithEnumWrapperTarget_ReturnsEnumWrapper()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var convertedOutput = (EnumWrapper<TestEnum>)converter.ConvertBack(inutValue, typeof(EnumWrapper<TestEnum>), null, null);

            // Assert
            convertedOutput.Should().Be(inutValue);
        }

        [Fact]
        public void ConvertBack_NullTargetType_ThrowsArgumentNullException()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            Action action = () => { converter.ConvertBack(inutValue, null, null, null); };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ConvertBack_NonEnumTargetType_ThrowsNotSupportedException()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            Action action = () => { converter.ConvertBack(inutValue, typeof(string), null, null); };

            // Assert
            action.Should().Throw<NotSupportedException>();
        }
    }
}
