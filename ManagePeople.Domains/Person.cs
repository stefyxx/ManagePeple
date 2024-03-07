using System.ComponentModel.DataAnnotations;

namespace ManagePeople.Domains
{
    public class Person
    {
        //3F2504E0-4F89-11D3-9A0C-0305E82C3301
        [Key]
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

    }
}
