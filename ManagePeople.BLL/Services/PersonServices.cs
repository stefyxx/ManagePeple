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

            //Not only have I created an specified Type ('CreatePersonDTO'), but I want to make sure that my properties are well filled
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
            //If --> NotFound
            if (found == null) throw new InvalidOperationException($"No person for this id '{id}'");
            else
            {
                //I imagined that you could change or just the first name or just the last name or both
                found.LastName = (lastName == null || lastName =="") ?  found.LastName : lastName;
                found.FirstName = (firstName == null || lastName == "") ?  found.FirstName : firstName;
                return _personRepository.Update(found);
            }
            
        }

        public void Delete(Guid id)
        {
            Person? deleted = _personRepository.GetById(id);
            if (deleted != null)
            {
                _personRepository.Delete(deleted);

                //I test that is really deleted:
                Person? reallyDeleted = _personRepository.GetById(id);
                if(reallyDeleted != null) throw new Exception("Deleted doesn't work!");

            }
            else throw new KeyNotFoundException($"No person with this id '{id}'");
        }
    }
}
