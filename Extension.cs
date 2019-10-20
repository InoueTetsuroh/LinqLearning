using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLearning
{
    public static class Extension
    {
        //LINQとは、その内部で処理をループして何かを処理するもの。
        //予め完全に決まっていたり(Sum,Average,etc)
        //処理の一部をラムダ式で与えたり(Where,Select,etc)
        //全部ラムダ式で与えたり(ForEach)する

        /// <summary>
        /// Linqではなく、ただの拡張メソッド
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string JoinIntoString(this IEnumerable<char> chars)
        {
            return new string(chars.ToArray());
        }

        /// <summary>
        /// Linqになってる。戻り値はスカラー。
        /// </summary>
        /// <param name="samples"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public static int SumValues(this IEnumerable<Sample> samples, Display display)
        {
            display.OutputLine("SamValues Start");

            int sum = 0;
            foreach (var s in samples)
            {
                sum = sum + s.Value;
                display.OutputLine($"[3] Sum: {s.Kind},{s.Value} <sum={sum}>");
            }
            display.OutputLine("SamValues End");
            return sum;

        }

        /// <summary>
        /// LessThen パターン１
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numbers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static IEnumerable<T> LessThen<T>(this IEnumerable<T> numbers, T threshold) where T : IComparable
        {
            return numbers.Where(i => i.CompareTo(threshold) < 0);
        }

        /// <summary>
        /// LessThen パターン２
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numbers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static IEnumerable<T> LessThenNotLinq<T>(this IEnumerable<T> numbers, T threshold) where T : IComparable
        {
            List<T> results = new List<T>();
            foreach(var v in numbers)
            {
                if(v.CompareTo(threshold) < 0)
                {
                    results.Add(v);
                }
            }
            return results;
        }

        /// <summary>
        /// LessThen パターン３（これが求めていたLinqメソッドの書き方）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numbers"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public static IEnumerable<T> LessThenNotList<T>(this IEnumerable<T> numbers, T threshold) where T : IComparable
        {
            foreach (var v in numbers)
            {
                if (v.CompareTo(threshold) < 0)
                {
                    yield return v;                    
                }
            }
        }

        public static IEnumerable<String> ToQuotedString<TSource>(this IEnumerable<TSource> numbers,
                                                                  Func<TSource,bool> predicate
                                                                  ) where TSource:IFormattable
        {
            foreach(var n in numbers)
            {
                bool match = predicate(n);
                if (match)
                {
                    yield return $"\"{n.ToString()}\"";
                }
            }
        }
    }
}
