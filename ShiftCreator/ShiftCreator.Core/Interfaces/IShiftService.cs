using ShiftCreator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Interfaces
{
    public interface IShiftService
    {
        IEnumerable<Shift> GetAllShifts();
        Shift GetShiftById(int id);
        void CreateShift(Shift shift);
        void UpdateShift(Shift shift);
        void DeleteShift(int id);
    }
}
