namespace ManagePeople.API.Models
{
    public class CreatePersonDTO
    {
        // I want the data (Json) sent to my API to be compliant 
        public required string lastName { get; set; } = null!;
        public required string firstName { get; set; } = null!;
    }
}
