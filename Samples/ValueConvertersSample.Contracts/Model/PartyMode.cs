﻿using ValueConverters.Annotations;
using ValueConvertersSample.Contracts.Resources;

namespace ValueConvertersSample.Contracts.Model
{
    public enum PartyMode
    {
        [Display(Name = "PartyMode_Off", ResourceType = typeof(PartyModeResources))]
        Off,

        [Display(Name = "PartyMode_On", ResourceType = typeof(PartyModeResources))]
        On,

        [Display(Name = "PartyMode_Maybe", ResourceType = typeof(PartyModeResources))]
        Maybe,
    }
}