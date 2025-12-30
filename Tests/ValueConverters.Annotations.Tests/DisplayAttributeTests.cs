using System.Globalization;
using FluentAssertions;
using ValueConvertersSample.Contracts.Model;

namespace ValueConverters.Annotations.Tests
{
    public class DisplayAttributeTests
    {
        [Theory]
        [ClassData(typeof(DisplayNameTestData))]
        public void ShouldReturnEnumDisplayText(PartyMode partyMode, CultureInfo? culture, EnumWrapperConverterNameStyle nameStyle, string? expectedResult)
        {
            // Act
            var partyModeString = DisplayAttribute.GetDisplayName(partyMode, nameStyle, culture);

            // Assert
            partyModeString.Should().Be(expectedResult);

        }

        public class DisplayNameTestData : TheoryData<PartyMode, CultureInfo?, EnumWrapperConverterNameStyle, string?>
        {
            public DisplayNameTestData()
            {
                var englishCulture = new CultureInfo("en");
                var germanCulture = new CultureInfo("de");

                this.Add(PartyMode.On, null, EnumWrapperConverterNameStyle.ShortName, "On");
                this.Add(PartyMode.On, englishCulture, EnumWrapperConverterNameStyle.ShortName, "On");
                this.Add(PartyMode.On, germanCulture, EnumWrapperConverterNameStyle.ShortName, "Ein");

                this.Add(PartyMode.On, null, EnumWrapperConverterNameStyle.LongName, "On");
                this.Add(PartyMode.On, englishCulture, EnumWrapperConverterNameStyle.LongName, "On");
                this.Add(PartyMode.On, germanCulture, EnumWrapperConverterNameStyle.LongName, "Ein");
            }
        }
    }

}
