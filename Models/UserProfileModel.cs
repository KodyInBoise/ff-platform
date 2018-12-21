using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Models
{
    public class UserProfileModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<string> FavoritePlayers { get; set; }
        public List<Guid> Teams { get; set; }


        public UserProfileModel()
        {
            FavoritePlayers = new List<string>();
        }

        public UserProfileModel(Guid userID)
        {
            ID = userID;
            FavoritePlayers = new List<string>();
        }
    }
}
