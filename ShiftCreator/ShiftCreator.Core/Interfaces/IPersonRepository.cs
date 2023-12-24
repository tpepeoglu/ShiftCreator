using ShiftCreator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeople();
        Person GetById(int id);
        void Delete(int id);
        void Update(Person person);
        void Add(Person person);        

    }
}
