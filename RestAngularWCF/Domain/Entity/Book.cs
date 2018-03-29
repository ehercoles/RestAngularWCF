using System.Runtime.Serialization;

namespace RestAngularWCF.Domain.Entity
{
    [DataContract]
    public class Book
    {
        [DataMember]
        int BookId { get; set; }
        [DataMember]
        string Name { get; set; }
    }
}