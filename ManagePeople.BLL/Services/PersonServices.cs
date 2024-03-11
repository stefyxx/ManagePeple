using ManagePeople.BLL.Interfaces;
using ManagePeople.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.BLL.Services
{
    public class PersonServices(IPersonRepository _personRepository)
    {
        public IEnumerable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public IEnumerable<Person> Search(string? lastName, string? firstName)
        {
            //DONE:
            //Filters must be case insensitive  --> SQL is not case sensitive
            //if (lastName != null) lastName.ToLower();
            //firstName = (firstName !=null)? firstName.ToLower() : null;

            return _personRepository.Search(lastName, firstName);
    
        }

        public Person? Get(Guid id)
        {
            return _personRepository.GetById(id);
        }

        public Person Register(Person person)
        {
            Guid id = Guid.NewGuid();
            person.Id = id;
            if (person.LastName == "" || person.LastName == null) throw new Exception("The last name is required");
            if (person.FirstName == "" || person.FirstName == null) throw new Exception("The first name is required");
            else
            {
                //I would like to do a little check: for example
                //a person wants to register but is already registered in DB 
                //this is not possible, because the way 'Person' was created, I could have two homonyms
                return _personRepository.Add(person);
            }
        }

        public Person Update(Guid id,  string? lastName, string? firstName)
        {
            // hard to imagine other controls, since 'person' has too few properties and I might have homonyms

            Person? found = _personRepository.GetById(id);
            if (found == null) throw new InvalidOperationException($"No person for thid id '{id}'");
            else
            {
                found.LastName = (lastName != null) ? lastName : found.LastName;
                found.FirstName = (firstName != null) ? firstName : found.FirstName;
                return _personRepository.Update(found);
            }
            
        }

        public void Delete(Guid id)
        {
            Person? deleted = _personRepository.GetById(id);
            if (deleted != null)
            {
                _personRepository.Delete(deleted);
            }
            else throw new Exception($"No person with this id '{id}'");
        }
    }
}
