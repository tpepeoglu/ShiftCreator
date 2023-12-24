using ShiftCreator.Core.Entities;
using ShiftCreator.Core.Interfaces;
using ShiftCreator.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Application.Services
{
    public class ApplicationServices
    {
        private readonly ITeamService _teamService;
        private readonly IPersonService _personService;
        private readonly IShiftService _shiftService;
        public ApplicationServices(ITeamService teamService,IPersonService personService,IShiftService shiftService)
        {
            _personService = personService;
            _teamService = teamService;
            _shiftService = shiftService;
        }
        public void CreateTeam(string teamName, int leaderPersonId, List<int> memberPersonIds)
        {
            var leaderPerson = _personService.GetPersonById(leaderPersonId);
            if (leaderPerson == null)
            {
                throw new Exception("The specified lead person could not be found.");
            }

            if (_teamService.GetAllTeams().Any(t => t.TeamLeaderId == leaderPersonId))
            {
                throw new Exception("This staff member has already been assigned as the leader of a team.");
            }

            var newTeam = new Team
            {
                TeamName = teamName,
                TeamLeader = leaderPerson
            };

            foreach (var memberId in memberPersonIds)
            {
                var memberPerson = _personService.GetPersonById(memberId);
                if (memberPerson != null)
                {
                    if (_teamService.GetAllTeams().Any(t => t.People.Any(m => m.Id == memberId)))
                    {
                        throw new Exception("These person are already on a team.");
                    }

                    newTeam.People.Add(memberPerson);
                }
            }
            _teamService.CreateTeam(newTeam);
        }
        public void AssignTeamsToShift(int shiftId, List<int> teamIds)
        {
            var shift = _shiftService.GetShiftById(shiftId);
            if (shift == null)
            {
                throw new Exception("The specified shift was not found.");
            }

            foreach (var teamId in teamIds)
            {
                var team = _teamService.GetTeamById(teamId);
                if (team != null)
                {
                    // Vardiyaya takımın atanması
                    shift.TeamId = teamId;
                    shift.Team = team;
                }
            }

            _shiftService.UpdateShift(shift);
        }
        public void TransferPersonBetweenTeams(int personId, int sourceTeamId, int destinationTeamId)
        {
            var person = _personService.GetPersonById(personId);
            if (person == null)
            {
                throw new Exception("The specified person could not be found.");
            }

            var sourceTeam = _teamService.GetTeamById(sourceTeamId);
            if (sourceTeam == null)
            {
                throw new Exception("The specified resource team could not be found.");
            }

            if (sourceTeam.TeamLeaderId  == personId)
            {
                throw new Exception("Since the person is the leader of the resource team, the transfer cannot be made.");

            }

            var destinationTeam = _teamService.GetTeamById(destinationTeamId);
            if (destinationTeam == null)
            {
                throw new Exception("The specified target team was not found.");
            }
            

            sourceTeam.People.Remove(person);
            destinationTeam.People.Add(person);

            _teamService.UpdateTeam(sourceTeam);
            _teamService.UpdateTeam(destinationTeam);
        }
    }
}
