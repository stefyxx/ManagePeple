using ManagePeople.BLL.Interfaces;
using ManagePeople.DAL.Context;
using ManagePeople.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context) { }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Search(string? lastName, string? firstName)
        {
            //Mes filtres sont optionnels; alors si je ne les écris pas, le 'Where' filtrera en agissant sur '== null' -->
            //cela signifie qu'il acceptera tous les noms / prénoms dans la table DB
            return _table
                .Where(p => lastName == null || p.LastName.StartsWith(lastName.Trim()) || p.LastName.EndsWith(lastName.Trim()))
                .Where(p => firstName == null || p.FirstName.StartsWith(firstName.Trim()) || p.FirstName.EndsWith(firstName.Trim()))
                .OrderBy(p=> p.LastName);
        }

        Person IPersonRepository.Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
