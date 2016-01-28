using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

using ValueConverters.NetFx.Tests.TestData;

using Xunit;
using FluentAssertions;

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
        public void ShouldConvertBackIfInputValueIsEnum()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            const TestEnum InutValue = TestEnum.Lorem;

            // Act
            var convertedOutput = (TestEnum)converter.ConvertBack(InutValue, null, null, null);

            // Assert
            convertedOutput.Should().Be(TestEnum.Lorem);
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
    }
}