namespace ValueConverters.Tests
{
    public class EnumWrapperTests
    {
        [Fact]
        public void ToString_DisplayNameResourceExists_ReturnsLocalizedText()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var localizedValue = enumWrapper.ToString();

            // Assert
            localizedValue.Should().Be("Lorem text");
            localizedValue.Should().Be(enumWrapper.LocalizedValue);
        }

        [Fact]
        public void LocalizedValue_DisplayNameResourceExists_ReturnsLocalizedText()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be("Lorem text");
        }

        [Fact]
        public void LocalizedValue_NonGenericReference_ReturnsLocalizedText()
        {
            // Arrange
            EnumWrapper enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be("Lorem text");
            localizedValue.Should().Be(enumWrapper.ToString());
        }

        [Fact]
        public void Value_NonGenericReference_ReturnsEnumValue()
        {
            // Arrange
            EnumWrapper enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var value = enumWrapper.Value;

            // Assert
            value.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void Value_GenericReference_ReturnsTypedEnumValue()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var value = enumWrapper.Value;

            // Assert
            value.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void ImplicitOperator_GenericReference_ReturnsEnumValue()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            TestEnum value = enumWrapper;

            // Assert
            value.Should().Be(TestEnum.Lorem);
        }

        [Fact]
        public void ImplicitIntOperator_GenericReference_ReturnsNumericEnumValue()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Dolor);

            // Act
            int value = enumWrapper;

            // Assert
            value.Should().Be((int)TestEnum.Dolor);
        }

        [Fact]
        public void Refresh_NonGenericReference_RaisesValueAndLocalizedValuePropertyChanged()
        {
            // Arrange
            EnumWrapper enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);
            var changedProperties = new List<string?>();
            enumWrapper.PropertyChanged += (_, args) => changedProperties.Add(args.PropertyName);

            // Act
            enumWrapper.Refresh();

            // Assert
            changedProperties.Should().Equal(nameof(EnumWrapper.Value), nameof(EnumWrapper.LocalizedValue));
        }

        [Fact]
        public void Refresh_GenericReference_RaisesValueAndLocalizedValuePropertyChanged()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Lorem);
            var changedProperties = new List<string?>();
            enumWrapper.PropertyChanged += (_, args) => changedProperties.Add(args.PropertyName);

            // Act
            enumWrapper.Refresh();

            // Assert
            changedProperties.Should().Equal(nameof(EnumWrapper<TestEnum>.Value), nameof(EnumWrapper<TestEnum>.LocalizedValue));
        }

        [Fact]
        public void Equals_NonGenericReferenceWithSameEnumValue_ReturnsTrue()
        {
            // Arrange
            EnumWrapper left = EnumWrapper.CreateWrapper(TestEnum.Lorem);
            EnumWrapper right = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var equals = left.Equals(right);

            // Assert
            equals.Should().BeTrue();
            left.GetHashCode().Should().Be(right.GetHashCode());
        }

        [Fact]
        public void Equals_NonGenericReferenceWithDifferentEnumValue_ReturnsFalse()
        {
            // Arrange
            EnumWrapper left = EnumWrapper.CreateWrapper(TestEnum.Lorem);
            EnumWrapper right = EnumWrapper.CreateWrapper(TestEnum.Dolor);

            // Act
            var equals = left.Equals(right);

            // Assert
            equals.Should().BeFalse();
        }

        [Fact]
        public void Equals_GenericReferenceWithSameEnumValue_ReturnsTrue()
        {
            // Arrange
            var left = EnumWrapper.CreateWrapper(TestEnum.Lorem);
            var right = EnumWrapper.CreateWrapper(TestEnum.Lorem);

            // Act
            var equals = left.Equals(right);

            // Assert
            equals.Should().BeTrue();
            (left == right).Should().BeTrue();
            (left != right).Should().BeFalse();
            left.GetHashCode().Should().Be(right.GetHashCode());
        }

        [Fact]
        public void Equals_GenericReferenceWithDifferentEnumValue_ReturnsFalse()
        {
            // Arrange
            var left = EnumWrapper.CreateWrapper(TestEnum.Lorem);
            var right = EnumWrapper.CreateWrapper(TestEnum.Dolor);

            // Act
            var equals = left.Equals(right);

            // Assert
            equals.Should().BeFalse();
            (left == right).Should().BeFalse();
            (left != right).Should().BeTrue();
        }

        [Fact]
        public void LocalizedValue_DisplayNameResourceMissing_ThrowsInvalidOperationException()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Ipsum);

            // Act
            Action action = () => _ = enumWrapper.LocalizedValue;

            // Assert
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void LocalizedValue_NoDisplayAttribute_ReturnsEnumName()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Dolor);

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be(nameof(TestEnum.Dolor));
        }

        [Fact]
        public void LocalizedValue_ThirdPartyDisplayAttribute_ReturnsEnumName()
        {
            // Arrange
            var enumWrapper = EnumWrapper.CreateWrapper(TestEnum.Fourth);

            // Act
            var localizedValue = enumWrapper.LocalizedValue;

            // Assert
            localizedValue.Should().Be(nameof(TestEnum.Fourth));
        }

        [Fact]
        public void CreateWrappers_TestEnum_ReturnsAllEnumValues()
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