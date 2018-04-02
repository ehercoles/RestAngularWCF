using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestAngularWCF.Domain.Entity
{
    [DataContract]
    public class Book
    {
        [DataMember]
        [Key]
        public int BookId { get; set; }

        [DataMember]
        [Required, StringLength(80)]
        public string Name { get; set; }
    }
}
