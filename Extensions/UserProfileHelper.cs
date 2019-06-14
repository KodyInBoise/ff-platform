using ff_platform.Data;
using ff_platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Extensions
{
    public class UserProfileHelper
    {
        public static UserProfileModel GetUserProfile(ApplicationDbContext database, string userID)
        {
            if (!Guid.TryParse(userID, out var userProfileID))
            {
                return null;
            }

            return database.UserProfiles.Find(userProfileID);
        }

        public static void AddOrUpdate(ApplicationDbContext database, UserProfileModel profile, out bool newProfile)
        {
            newProfile = database.UserProfiles.FirstOrDefault(u => u.ID == profile.ID) == null;

            if (newProfile)
            {
                database.UserProfiles.Add(profile);
            }
            else
            {
                database.UserProfiles.Update(profile);
            }

            database.SaveChanges();
        }
    }
}
