using System.ComponentModel.DataAnnotations;

namespace ManagePeople.Domain
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
