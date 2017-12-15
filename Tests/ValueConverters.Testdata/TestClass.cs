using System.Runtime.Serialization;

namespace ValueConverters.Testdata
{
    [DataContract]
    public class TestClass
    {
        [DataMember]
        public TestEnum TestEnum { get; set; }
    }
}
