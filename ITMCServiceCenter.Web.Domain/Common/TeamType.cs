using System.Runtime.Serialization;

namespace ITMCServiceCenter.Web.Domain
{
    [DataContract]
    public enum TeamType
    {
        [EnumMember]
        Implementation,
        [EnumMember]
        Testing
    }
}
