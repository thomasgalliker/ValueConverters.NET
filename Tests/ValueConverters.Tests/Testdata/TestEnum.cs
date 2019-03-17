using System;
using System.Runtime.Serialization;
using ValueConverters.Annotations;

namespace ValueConverters.Tests.Testdata
{
    [DataContract]
    public enum TestEnum
    {
        [EnumMember]
        [Display(Name = "LoremText", ShortName = "LoremText_Short", ResourceType = typeof(AppResources))]
        Lorem,

        [EnumMember]
        [Display(Name = "IpsumText", ResourceType = typeof(AppResources))]
        Ipsum,

        Dolor, // Test if conversion works without annotation

        [TestAnnotations.Display] // Test if handling of third-party DisplayAttribute works
        Fourth
    }


}

namespace ValueConverters.Tests.Testdata.TestAnnotations
{
    public class DisplayAttribute : Attribute
    { }
}