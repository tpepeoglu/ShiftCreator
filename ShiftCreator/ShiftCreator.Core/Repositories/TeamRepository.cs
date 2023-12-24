using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly List<Team> _team = new List<Team>();
        public IEnumerable<Team> GetTeams() => _team;
        public Team GetById(int id) => _team.FirstOrDefault(p => p.Id == id);
        public void Add(Team team) => _team.Add(team);
        public void Update(Team team)
        {
            var existingTeam = _team.FirstOrDefault(p => p.Id == team.Id);
            if (existingTeam != null)
            {
                existingTeam.TeamLeader = team.TeamLeader;
                existingTeam.TeamLeaderId = team.TeamLeaderId;
                existingTeam.TeamName = team.TeamName;
                existingTeam.Shifts = team.Shifts;
                existingTeam.People = team.People;
            }
        }

        public void Delete(int id)
        {
            var teamToRemove = _team.FirstOrDefault(p => p.Id == id);
            if (teamToRemove != null)
            {
                _team.Remove(teamToRemove);
            }
        }
    }
}
