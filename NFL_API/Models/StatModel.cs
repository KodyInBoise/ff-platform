using System;

namespace ff_platform.NFL_API
{
    public class StatModel
    {
        public int ID { get; set; }
        public string Abbr { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int Value { get; set; }

        public StatModel(int value = 0)
        {
            Value = value;
        }

        public static StatModel Copy(StatModel stat, int value = 0)
        {
            return new StatModel(value)
            {
                ID = stat.ID,
                Abbr = stat.Abbr,
                Name = stat.Name, 
                ShortName = stat.ShortName,
            };
        }
    }
}
