using ManagePeople.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Context
{
    //
    public static class DataSeeders
    {
        //J'initialise ma table 'Person' dans le DB avec l'insertion de quelques personnes
        //C'est complètement facultatif, mais cela me permet de tester rapidement les méthodes dans mon Controller




        public static IEnumerable<Person> InitPeople()
        {
            yield return new Person() { Id = new Guid(), FirstName = "Josephine", LastName = "Smith" };
            yield return new Person() { Id = new Guid(), FirstName = "Michael", LastName = "Johnson" };
            yield return new Person() { Id = new Guid(), FirstName = "Daniel", LastName = "Williams" };
            yield return new Person() { Id = new Guid(), FirstName = "Charles", LastName = "Wilson" };
            yield return new Person() { Id = new Guid(), FirstName = "Samuel", LastName = "Donet" };


        }
    }
}
