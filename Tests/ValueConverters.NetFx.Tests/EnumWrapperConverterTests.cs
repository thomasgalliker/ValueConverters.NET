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

            // Assert
            convertedOutput.ToString().Should().Be(TestEnum.Ipsum.ToString());
        }

        [Fact]
        public void ShouldConvertIfNoAnnotationAvailable()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();
            const TestEnum InutValue = TestEnum.Dolor;

            // Act
            var convertedOutput = converter.Convert(InutValue, null, null, null);

            // Assert
            convertedOutput.ToString().Should().Be(TestEnum.Dolor.ToString());
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionOnConvertBack()
        {
            // Arrange
            IValueConverter converter = new EnumWrapperConverter();

            const TestEnum InutValue = TestEnum.Ipsum;

            // Act
            Action action = () => converter.ConvertBack(InutValue, null, null, null);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
