using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLearning
{
    public static class Extension
    {
        public static string JoinIntoString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }
    }
}
