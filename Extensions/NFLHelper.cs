using System;

namespace ff_platform.Extensions
{
    public class NFLHelper
    {
        public static int GetCurrentSeason()
        {
            return 2018;
        }

        public static int GetCurrentWeek()
        {
            return 15;
        }

        // TODO: Unit test for > 10
        public static DateTime GetPreseasonStartDate(int year)
        {
            var datetime = new DateTime(year, 09, 01);

            var day = datetime.Day;
            switch (datetime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    day += DayOfWeek.Thursday - DayOfWeek.Sunday;
                    break;
                case DayOfWeek.Monday:
                    day += DayOfWeek.Thursday - DayOfWeek.Monday;
                    break;
                case DayOfWeek.Tuesday:
                    day += 7 + (DayOfWeek.Thursday - DayOfWeek.Tuesday);
                    break;
                case DayOfWeek.Wednesday:
                    day += 7 + (DayOfWeek.Thursday - DayOfWeek.Wednesday);
                    break;
                case DayOfWeek.Thursday:
                    day += 7;
                    break;
                case DayOfWeek.Friday:
                    day += 6;
                    break;
                case DayOfWeek.Saturday:
                    day += 5;
                    break;
            }

            return new DateTime(year, 09, day);
        }

        public class Leagues
        {
            public static Guid WildcardLeagueID => Guid.Parse("db39f954-7399-4c27-aecc-a200d02669c4");
        }
    }
}