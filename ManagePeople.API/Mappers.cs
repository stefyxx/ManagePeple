using ManagePeople.API.Models;
using ManagePeople.Domain;

namespace ManagePeople.API
{
    public static class Mappers
    {
        public static Person ToDAL(this PersonDTO p)
        {
            return new Person()
            {
                LastName = p.lastName,
                FirstName = p.firstName
            };
        }
    }
}
