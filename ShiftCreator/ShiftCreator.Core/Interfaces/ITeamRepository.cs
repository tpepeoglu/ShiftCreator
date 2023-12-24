using ShiftCreator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetById(int id);
        void Add(Team team);
        void Update(Team team);
        void Delete(int id);
    }
}
