using System;
using System.Linq;
using FluentAssertions;
using ValueConverters.Tests.Testdata;
using Xunit;

namespace ValueConverters.NetFx.Tests
{
    public class EnumWrapperTests
    {
        [Fact]
        public void ShouldReturnToString()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            const string ExpectedLocalizationLorem = "Lorem text";

            // Act
            var localizedValue = enumWrapper.ToString();

            // Assert
            localizedValue.Should().Be(ExpectedLocalizationLorem);
            localizedValue.Should().Be(enumWrapper.LocalizedValue);
        }

        [Fact]
        public void ShouldReturnLocalizedValue()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            const string ExpectedLocalizationLorem = "Lorem text";

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be(ExpectedLocalizationLorem);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExpectionIfDisplayNameResourceCannotBeFound()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Ipsum);

            // Act
            Action action = () => { var x = enumWrapper.LocalizedValue; };

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void ShouldReturnEnumToStringIfNoDisplayAttributeIsSet()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Dolor);

            string expectedLocalizationDolor = TestEnum.Dolor.ToString();

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be(expectedLocalizationDolor);
        }

        [Fact]
        public void ShouldReturnEnumToStringIfInvalidDisplayAttributeIsSet()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Fourth);

            string expectedLocalizationFourth = TestEnum.Fourth.ToString();

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be(expectedLocalizationFourth);
        }

        [Fact]
        public void ShouldCreateWrappers()
        {
            // Act
            var enumWrappers = EnumWrapper.CreateWrappers<TestEnum>().ToArray();

            // Assert
            enumWrappers.Should().HaveCount(4);

            enumWrappers[0].Value.Should().Be(TestEnum.Lorem);
            enumWrappers[1].Value.Should().Be(TestEnum.Ipsum);
            enumWrappers[2].Value.Should().Be(TestEnum.Dolor);
            enumWrappers[3].Value.Should().Be(TestEnum.Fourth);
        }
    }
}
