using ManagePeople.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.BLL.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        IEnumerable<Person> Search(string? lastName, string? firstName);

        Person? GetById(Guid id);
        Person Add(Person person);
        Person Update(Person person);
        void Delete(Person person);

        IEnumerable<FirstName> GetAllFirstName();

    }
}
