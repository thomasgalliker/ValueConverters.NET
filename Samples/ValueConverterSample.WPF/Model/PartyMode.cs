using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

using ValueConverterSample.WPF.Resources;

namespace ValueConverterSample.WPF.Model
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