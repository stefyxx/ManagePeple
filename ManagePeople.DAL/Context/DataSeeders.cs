using ManagePeople.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Context
{
    public static class DataSeeders
    {
        public static IEnumerable<Person> InitPeople()
        {
            yield return new Person() { Id = Guid.NewGuid(), FirstName = "Josephine", LastName = "Smith" };
            yield return new Person() { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Johnson" };
            yield return new Person() { Id = Guid.NewGuid(), FirstName = "Daniel", LastName = "Williams" };
            yield return new Person() { Id = Guid.NewGuid(), FirstName = "Charles", LastName = "Wilson" };
            yield return new Person() { Id = Guid.NewGuid(), FirstName = "Samuel", LastName = "Donet" };

        }
    }
}
