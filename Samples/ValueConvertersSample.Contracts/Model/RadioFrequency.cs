using ValueConverters.Annotations;
using ValueConvertersSample.Contracts.Resources;

namespace ValueConvertersSample.Contracts.Model
{
    public enum RadioFrequency
    {
        [Display(Name = "Undefined", ResourceType = typeof(RadioFrequencyResources))]
        Undefined,

        [Display(Name = "LowFrequencyText", ResourceType = typeof(RadioFrequencyResources))]
        LF,

        [Display(Name = "MediumFrequencyText", ResourceType = typeof(RadioFrequencyResources))]
        MF,

        [Display(Name = "HighFrequencyText", ResourceType = typeof(RadioFrequencyResources))]
        HF,
    }
}