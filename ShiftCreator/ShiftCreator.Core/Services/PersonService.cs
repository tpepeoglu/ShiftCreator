using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAllPeople() => _personRepository.GetPeople();

        public Person GetPersonById(int id) => _personRepository.GetById(id);

        public void AddPerson(Person person) => _personRepository.Add(person);

        public void UpdatePerson(Person person) => _personRepository.Update(person);

        public void DeletePerson(int id) => _personRepository.Delete(id);

    }
}
