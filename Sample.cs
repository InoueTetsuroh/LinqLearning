using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLearning
{
    public class Sample
    {
        public string Kind { get; set; }
        public int Value { get; set; }

        public static Sample CreateFromCsvFile(string line)
        {
            string[] items = line.Split(',');
            return new Sample
            {
                Kind = items[0],
                Value = int.Parse(items[1]),
            };
        }

        public static bool IsKindA(Sample s)
        {
            bool isKindA = s.Kind == "A";
            return isKindA;
        }

    }

}
