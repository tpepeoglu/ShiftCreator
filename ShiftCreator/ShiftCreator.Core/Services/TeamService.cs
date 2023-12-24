using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IEnumerable<Team> GetAllTeams() => _teamRepository.GetTeams();

        public Team GetTeamById(int id) => _teamRepository.GetById(id);

        public void CreateTeam(Team Team) => _teamRepository.Add(Team);

        public void UpdateTeam(Team Team) => _teamRepository.Update(Team);

        public void DeleteTeam(int id) => _teamRepository.Delete(id);
    }
}
