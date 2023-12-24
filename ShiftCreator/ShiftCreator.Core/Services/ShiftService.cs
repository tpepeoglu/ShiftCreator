using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;

        public ShiftService(IShiftRepository ShiftRepository)
        {
            _shiftRepository = ShiftRepository;
        }

        public IEnumerable<Shift> GetAllShifts() => _shiftRepository.GetShifts();

        public Shift GetShiftById(int id) => _shiftRepository.GetById(id);

        public void CreateShift(Shift Shift) => _shiftRepository.Add(Shift);

        public void UpdateShift(Shift Shift) => _shiftRepository.Update(Shift);

        public void DeleteShift(int id) => _shiftRepository.Delete(id);
    }
}
