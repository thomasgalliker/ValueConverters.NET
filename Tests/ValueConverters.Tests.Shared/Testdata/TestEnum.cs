using System;
using System.Runtime.Serialization;
using ValueConverters.Tests.Testdata;

namespace ValueConverters.Tests.Testdata
{
    [DataContract]
    public enum TestEnum
    {
        [EnumMember]
        [Annotations.Display(Name = "LoremText", ShortName = "LoremText_Short", ResourceType = typeof(AppResources))]
        Lorem,

        [EnumMember]
        [Annotations.Display(Name = "IpsumText", ResourceType = typeof(AppResources))]
        Ipsum,

        Dolor, // Test if conversion works without annotation

        [Display] // Test if handling of third-party DisplayAttribute works
        Fourth
    }

    public class DisplayAttribute : Attribute
    { }
}