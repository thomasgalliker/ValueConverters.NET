using System.Runtime.Serialization;

namespace ValueConverters.Tests.Testdata
{
    [DataContract]
    public class TestClass
    {
        [DataMember]
        public TestEnum TestEnum { get; set; }
    }
}
