using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Repositories
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly List<Shift> _shift = new List<Shift>();
        public IEnumerable<Shift> GetShifts() => _shift;
        public Shift GetById(int id) => _shift.FirstOrDefault(p => p.Id == id);
        public void Add(Shift shift) => _shift.Add(shift);
        public void Update(Shift shift)
        {
            var existingShift = _shift.FirstOrDefault(p => p.Id == shift.Id);
            if (existingShift != null)
            {
                existingShift.ShiftName = shift.ShiftName;
                existingShift.StartTime = shift.StartTime;
                existingShift.EndTime = shift.EndTime;
                existingShift.Team = shift.Team;
                existingShift.TeamId = shift.TeamId;
            }
        }

        public void Delete(int id)
        {
            var shiftToRemove = _shift.FirstOrDefault(p => p.Id == id);
            if (shiftToRemove != null)
            {
                _shift.Remove(shiftToRemove);
            }
        }
    }
}
