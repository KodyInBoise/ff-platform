using System;
using System.Collections.Generic;

namespace ff_platform.Models
{
    public class TeamModel
    {
        public Guid ID { get; set; }
        public Guid OwnerID { get; set; }
        public Guid LeagueID { get; set; }
        public List<string> PlayerIDs { get; set; }


        public TeamModel()
        {

        }

        public TeamModel(Guid ownerID, Guid leagueID)
        {
            OwnerID = ownerID;
            LeagueID = leagueID;
        }

        public void Copy(TeamModel team)
        {
            OwnerID = team.OwnerID;
            LeagueID = team.LeagueID;
            Name = team.Name;
            PlayerIDs = team.PlayerIDs;
        }
    }
}