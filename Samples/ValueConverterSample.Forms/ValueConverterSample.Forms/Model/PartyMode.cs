using System.Runtime.Serialization;

using ValueConverters.Annotations;

using ValueConverterSample.Forms.Resources;

namespace ValueConverterSample.Forms.Model
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