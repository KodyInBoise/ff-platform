using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.ApiUtil.ResponseModels
{
    public class NflGameModel
    {
        public string nflGameId { get; set; }
        public string nflGameCenterUrl { get; set; }
        public DateTime gameDateAndTime { get; set; }
        public string gameStatus { get; set; }
        public string gameClock { get; set; }
        public string playStatusDisplay { get; set; }
        public bool isOffenseInRedZone { get; set; }
        public string network { get; set; }
        public int lastStatFileProcessed { get; set; }
        public string lastClockTimeProcessed { get; set; }
        public bool isGameRosterLocked { get; set; }
        public List<PlayerModel> onTheFieldPlayers { get; set; }
        public TeamModel homeTeam { get; set; }
        public TeamModel awayTeam { get; set; }

        public static NflGameModel ParseObject(JToken token)
        {
            var game = new NflGameModel();

            var t = token.Children().Children();
            game.nflGameId = t.Values<string>("nflGameId");

            return game;
        }
    }
}
