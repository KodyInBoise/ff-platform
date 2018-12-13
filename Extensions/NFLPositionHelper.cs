using ff_platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ff_platform.Extensions
{
    public class NFLPositionHelper
    {
        public enum PositionEnum : int
        {
            QB, 
            RB, 
            WR, 
            TE,
            FB,
            K,
            FLEX
        }


        public class Offensive
        {
            public class Quarterback
            {
                public static string Name = "Quarterback";
                public static string Abbreviation = "QB";
                public PositionEnum Enum = PositionEnum.QB;

                public override string ToString()
                {
                    return Name;
                }
            }

            public class RunningBack
            {
                public static string Name = "Running Back";
                public static string Abbreviation = "RB";
                public PositionEnum Enum = PositionEnum.RB;

                public override string ToString()
                {
                    return Name;
                }
            }

            public class FullBack
            {
                public static string Name = "Fullback";
                public static string Abbreviation = "FB";
                public PositionEnum Enum = PositionEnum.QB;

                public override string ToString()
                {
                    return Name;
                }
            }

            public class WideReceiver
            {
                public static string Name = "Wide Receiver";
                public static string Abbreviation = "WR";
                public PositionEnum Enum = PositionEnum.QB;

                public override string ToString()
                {
                    return Name;
                }
            }

            public class TightEnd
            {
                public static string Name = "Tight End";
                public static string Abbreviation = "TE";
                public PositionEnum Enum = PositionEnum.QB;

                public override string ToString()
                {
                    return Name;
                }
            }

            public class Kicker
            {
                public static string Name = "Kicker";
                public static string Abbreviation = "K";
                public PositionEnum Enum = PositionEnum.QB;

                public override string ToString()
                {
                    return Name;
                }
            }

            public class Flex
            {
                public static string Name = "Flex";
                public static string Abbreviation = "FLEX";
                public PositionEnum Enum = PositionEnum.FLEX;

                public override string ToString()
                {
                    return Name;
                }
            }
        }

        public class Deffensive
        {

        }
    }
}


/*
Quarterback (QB) 
Running Back (RB) 
Fullback (FB)
Wide Receivers (WR)
Tight End (TE)
Offensive Line
 */
