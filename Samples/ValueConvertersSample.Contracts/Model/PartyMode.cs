using System.Runtime.Serialization;

using ValueConverters.Annotations;

using ValueConverterSample.Resources;

namespace ValueConverterSample.Model
{
    [DataContract]
    public enum PartyMode
    {
        [EnumMember]
        [Display(Name = "PartyMode_Off", ResourceType = typeof(PartyModeResources))]
        Off,

        [EnumMember]
        [Display(Name = "PartyMode_On", ResourceType = typeof(PartyModeResources))]
        On,

        [EnumMember]
        [Display(Name = "PartyMode_Maybe", ResourceType = typeof(PartyModeResources))]
        Maybe,
    }
}