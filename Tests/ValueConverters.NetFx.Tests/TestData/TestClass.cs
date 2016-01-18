using System.Runtime.Serialization;

namespace ValueConverters.NetFx.Tests.TestData
{
    [DataContract]
    public class TestClass
    {
        [DataMember]
        public TestEnum TestEnum { get; set; }
    }
}
