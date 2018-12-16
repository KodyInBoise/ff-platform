using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform
{
    public class UserPreferencesModel
    {
        public Guid UserID { get; set; }
        public List<string> FavoritePlayers { get; set; }
    }
}
