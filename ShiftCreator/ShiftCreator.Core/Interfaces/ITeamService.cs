using ShiftCreator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Interfaces
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeams();
        Team GetTeamById(int id);
        void CreateTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(int id);
    }
}
