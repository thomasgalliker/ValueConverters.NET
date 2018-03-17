using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using ValueConverters.Testdata;
using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class EnumWrapperConverterTests
    {
        [Fact]
        public void ShouldConvert()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InutValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.Convert(InutValue, null, null, null);

            // Assert
            convertedOutput.ToString().Should().Be(AppResources.LoremText);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionIfAppResourceCannotBeFound()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InutValue = TestEnum.Ipsum;

            // Act
            var convertedOutput = converter.Convert(InutValue, null, null, null);
            Action action = () => convertedOutput.ToString();

            // Assert
            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void ShouldConvertIfNoAnnotationAvailable()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InutValue = TestEnum.Dolor;
            string expectedOutput = InutValue.ToString();

            // Act
            var convertedOutput = converter.Convert(InutValue, null, null, null);

            // Assert
            convertedOutput.ToString().Should().Be(expectedOutput);
        }

        [Fact]
        public void ShouldConvertGenericEnumerable()
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
        public void ShouldConvertBackIfInputValueIsEnum()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            const TestEnum InutValue = TestEnum.Lorem;

            // Act
            var convertedOutput = (TestEnum)converter.ConvertBack(InutValue, typeof(TestEnum), null, null);

            // Assert
            convertedOutput.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void ShouldConvertBackIfInputValueIsEnumAndTargetTypeIsNullableEnum()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            const TestEnum InutValue = TestEnum.Lorem;

            // Act
            var convertedOutput = (TestEnum)converter.ConvertBack(InutValue, typeof(TestEnum?), null, null);

            // Assert
            convertedOutput.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void ShouldCreateMapper()
        {
            // Arrange
            var converter = new EnumWrapperConverter();

            const TestEnum InutValue = TestEnum.Lorem;

            // Act
            var convertedOutput = converter.CreateMapper<TestEnum>(InutValue);

            // Assert
            convertedOutput.Value.Should().Be(TestEnum.Lorem);
            convertedOutput.LocalizedValue.Should().Be("Lorem text");
        }

        [Fact]
        public void ShouldConvertBackIfInputValueIsEnumWrapper()
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
        public void ShouldThrowArgumentNullExceptionOnConvertBackIfTargetTypeIsNull()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            Action action = () => { converter.ConvertBack(inutValue, null, null, null); };

            // Assert
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ShouldThrowInvalidCastExceptionOnConvertBackIfTargetTypeDoesNotMatch()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            var inutValue = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            Action action = () => { converter.ConvertBack(inutValue, typeof(string), null, null); };

            // Assert
            action.ShouldThrow<InvalidCastException>();
        }
    }
}