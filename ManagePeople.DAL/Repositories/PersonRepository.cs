using ManagePeople.BLL.Interfaces;
using ManagePeople.DAL.Context;
using ManagePeople.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Repositories
{
    public class PersonRepository(ManagePeopleContext _context) : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            return _context.Set<Person>().ToList();
        }

        public IEnumerable<Person> Search(string? lastName, string? firstName)
        {
            //DONE:
            //1) lastName/ firstName Not equal "" (string.Empty), but possibility null
            //2) to search at the beginning or at the end of the 'name'

            //Explication pa pt:
            //1) Mes filtres sont optionnels; alors si je ne les écris pas, le 'Where' filtrera en agissant sur '== null' -->
            //cela signifie qu'il acceptera tous les noms / prénoms dans la table DB

            //2) StartsWith et EndsWith --> j'ai ajouté en plus Trim pour effacer les espaces vides au début et a la fin de la string
            IEnumerable<Person> p = _context.Set<Person>()
                .Where(p => lastName == null || p.LastName.StartsWith(lastName.Trim()) || p.LastName.EndsWith(lastName.Trim()))
                //|| p.LastName.EndsWith(lastName.Trim()))
                .Where(p => firstName == null || p.FirstName.StartsWith(firstName.Trim()) || p.FirstName.EndsWith(firstName.Trim()))
                //|| p.FirstName.EndsWith(firstName.Trim()))
                .OrderBy(p => p.LastName);
            return p;
        }
        public Person? GetById(Guid id)
        {
            return _context.Person.Find(id);
        }

        public Person Add(Person person)
        {
            Person inserted = _context.Person.Add(person).Entity;
            _context.SaveChanges();
            return inserted;
        }
        public Person Update(Person person)
        {
            Person? updated = _context.Update(person).Entity;
            _context.SaveChanges();
            return updated;
        }

        public void Delete(Person deleted)
        {
            _context.Person.Remove(deleted);
            _context.SaveChanges();
        }
    }
}
