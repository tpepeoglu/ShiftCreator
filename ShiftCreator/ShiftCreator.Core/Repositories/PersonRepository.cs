using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly List<Person> _people = new List<Person>();
        public IEnumerable<Person> GetPeople() => _people;
        public Person GetById(int id) => _people.FirstOrDefault(p => p.Id == id);
        public void Add(Person person) => _people.Add(person);
        public void Update(Person person)
        {
            var existingPerson = _people.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Status = person.Status;
                existingPerson.Surname = person.Surname;
                existingPerson.PersonUserName = person.PersonUserName;
                existingPerson.Adress = person.Adress;
                existingPerson.EmailAdress = person.EmailAdress;
                existingPerson.IsAdmin = person.IsAdmin;
                existingPerson.PersonCode = person.PersonCode;
                existingPerson.PersonTitle = person.PersonTitle;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.TeamLeaderOfTeam = person.TeamLeaderOfTeam;
                existingPerson.TeamLeaderOfTeamId   = person.TeamLeaderOfTeamId;
                existingPerson.TeamId = person.TeamId;
                existingPerson.Team = person.Team;
            }        
        }

        public void Delete(int id)
        {
            var personToRemove = _people.FirstOrDefault(p => p.Id == id);
            if (personToRemove != null)
            {
                _people.Remove(personToRemove);
            }
        }
    }
}
