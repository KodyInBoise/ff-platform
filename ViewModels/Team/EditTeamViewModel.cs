using System;
using ff_platform.Models;

namespace ff_platform.ViewModels
{
    public class EditTeamViewModel
    {
        public TeamModel Team { get; set; }
        public string LeagueName { get; set; }


        public void SetTeam(TeamModel team)
        {
            Team = team;
        }
    }
}