using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform
{
    public class UserPrefsModel
    {
        public Guid ID { get; set; }
        public List<string> FavoritePlayers { get; set; }


        public static UserPrefsModel GetDefaults()
        {
            return new UserPrefsModel()
            {
                FavoritePlayers = new List<string>(),
            };
        }
    }
}
