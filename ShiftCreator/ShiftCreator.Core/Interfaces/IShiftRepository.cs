using ShiftCreator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Interfaces
{
    public interface IShiftRepository
    {
        IEnumerable<Shift> GetShifts();
        Shift GetById(int id);
        void Add(Shift shift);
        void Update(Shift shift);
        void Delete(int id);
    }
}
