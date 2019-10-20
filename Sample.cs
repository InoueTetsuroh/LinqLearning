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

        public static Sample CreateFromCsvFile(Display display,string line)
        {
            display.OutputLine($"[1] Select: {line}");
            string[] items = line.Split(',');
            return new Sample
            {
                Kind = items[0],
                Value = int.Parse(items[1]),
            };
        }

        public static bool IsKindA(Display display,Sample s)
        {
            bool isKindA = s.Kind == "A";
            display.OutputLine($"[2] Where: {s.Kind},{s.Value}({isKindA})");
            return isKindA;
        }

    }

}
