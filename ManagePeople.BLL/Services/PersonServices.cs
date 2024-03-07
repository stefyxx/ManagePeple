using ManagePeople.BLL.Interfaces;
using ManagePeople.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ManagePeople.BLL.Services
{
    public class PersonServices(IPersonRepository _personRepository)
    {
        public IEnumerable<Person> GetAll()
        {

            //TODO
            //piu' appelli a db --> si? using TransactionScope scope = new TransactionScope(); --> scope.Complete();
            //1: Filter
            return _personRepository.GetAll(); 
        }

        public IEnumerable<Person> Search(string? lastName, string? firstName)
        {
            return _personRepository.Search(lastName, firstName); 
        }
        public Person? Find(Guid id)
        {
            try
            {
                Person? personFound = _personRepository.GetById(id);
                if (personFound == null) throw new Exception($"No person for this id:  {id} ");
                else return personFound;
            }
            catch (Exception)
            {
                throw new Exception($"No person for this id:  {id} ");
            }
        }
        public Person? Register(Person p)
        {
            try
            {
                //DONE: firstNamer e/o lastName != "" (vide)
                if (p.FirstName == "") throw new Exception("The first name cannot be empty");
                if (p.LastName == "") throw new Exception("The last name cannot be empty");
                Person newPerson = _personRepository.Add(new Person()
                {
                    Id = new Guid(),
                    FirstName = p.FirstName, 
                    LastName = p.LastName
                });
                return newPerson;

            }
            catch (Exception)
            {
                throw new Exception("It was not possible to register");
            }
        }

        public Person Update(Person p)
        {
            return _personRepository.Update(p);
        }

        public void Delete(int id)
        {
            //TODO: 
            // a riflettere cancello ricevendo un Id
            //o cancello avendo una Person p?
            _personRepository.Delete(id);
        }

        public void Remove(Person p)
        {
            using TransactionScope scope = new TransactionScope();

            Person? person = _personRepository.GetById(p.Id);
            _personRepository.Remove(p);
            scope.Complete();
        }


    }
}
