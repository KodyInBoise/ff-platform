using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ff_platform.NFL_API
{
    public class WeeklyPlayerStatsModel
    {
        public string statType { get; set; }
        public int season { get; set; }
        public int week { get; set; }
        public List<PlayerModel> players { get; set; }

        public static WeeklyPlayerStatsModel Deserialize(string json)
        {
            List<PlayerModel> playerList = new List<PlayerModel>();

            dynamic playerstats = JObject.Parse(json);

            var players = playerstats["players"].Children();
            foreach (var player in players)
            {
                playerList.Add(PlayerModel.ParseObject(player));
            }

            return null;
        }
    }
}
