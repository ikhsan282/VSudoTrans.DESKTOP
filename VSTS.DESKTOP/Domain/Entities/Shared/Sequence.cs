using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Shared
{
    public class Sequence
    {
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "The {0} can not have more than {1} characters")]
        public string TypeName { get; set; } 

        [StringLength(100, ErrorMessage = "The {0} can not have more than {1} characters")]
        public string Prefix { get; set; } 

        public int NextId { get; set; }

        [Timestamp]
        public byte[] Version { get; set; } 
    }
}
