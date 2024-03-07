using ManagePeople.Domains;
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

        //TODO: delete a riflettere
        void Remove(Person p);
        void Delete(int id);

    }
}
