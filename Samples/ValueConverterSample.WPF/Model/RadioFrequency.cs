using System.Runtime.Serialization;

using ValueConverters.Annotations;

using ValueConverterSample.WPF.Resources;

namespace ValueConverterSample.WPF.Model
{
    [DataContract]
    public enum RadioFrequency
    {
        [EnumMember]
        [Display(Name = "Undefined", ResourceType = typeof(RadioFrequencyResources))]
        Undefined,

        [EnumMember]
        [Display(Name = "LowFrequencyText", ResourceType = typeof(RadioFrequencyResources))]
        LF,

        [EnumMember]
        [Display(Name = "MediumFrequencyText", ResourceType = typeof(RadioFrequencyResources))]
        MF,

        [EnumMember]
        [Display(Name = "HighFrequencyText", ResourceType = typeof(RadioFrequencyResources))]
        HF,
    }
}