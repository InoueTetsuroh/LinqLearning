using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LinqLearning
{
    public class DisplayService
    {
        public void MainService(Display display)
        {
            UseIEnumerableInt(display);

            display.OutputLine(""); //改行

            UseIEnumerableString(display);

            display.OutputLine(""); //改行

            UseCsvFile(display);
        }

        private void UseIEnumerableString(Display display)
        {
            string str = "LINQ Linq linq";

            display.OutputLine("◇大文字だけCount パターン１");
            display.OutputLine(str.Where(s => char.IsUpper(s)).Count());
            display.OutputLine("◇大文字だけCount パターン２");
            display.OutputLine(str.Count(v => char.IsUpper(v)));

            display.OutputLine("◇CSVファイルの奇数だけ取得");

            //csvファイルを扱う想定
            str = "1番目,2番目,3番目,4番目,5番目";

            display.WriteStrings(str.Split(',').Where((s, i) => i % 2 == 0));

            display.OutputLine("◇文字列コレクションから「ぶた」を取得");

            string[] sampleData = { "ぶた", "こぶた", "ぶたまん", "ねぶたまつり", "ねぷたまつり", "きつね", "ねこ" };

            //正規表現(System.Text.RegularExpressions;)
            var regex = new Regex("ぶた", RegexOptions.Compiled);

            display.WriteStrings(sampleData.Where(s => regex.IsMatch(s)));

            display.OutputLine("◇正規表現 AND検索");

            var regex1 = new Regex("ぶた", RegexOptions.Compiled);
            var regex2 = new Regex("たま", RegexOptions.Compiled);

            display.WriteStrings(sampleData.Where(s => regex1.IsMatch(s) && regex2.IsMatch(s)));

            display.OutputLine("◇正規表現 AND検索 個数不定");

            List<Regex> regexList = new List<Regex>()
            {
                new Regex("ぶた", RegexOptions.Compiled),
                new Regex("たま", RegexOptions.Compiled),
            };

            IEnumerable<String> work = sampleData; //最初にworkへ全部セットしてからwork.Whereで絞り込んだ結果で絞り込んでいく
            foreach (Regex r in regexList)
                work = work.Where(s => r.IsMatch(s));
            display.WriteStrings(work);

            display.OutputLine("◇正規表現 AND検索 個数不定 パターン２");

            work = sampleData;
            work = work.Where(s => regexList.All(r => r.IsMatch(s)));　// sampleData.Whereではない！
            display.WriteStrings(work);

            display.OutputLine("◇正規表現 OR検索 個数不定");

            work = new List<string>(); //空の状態からsampleData.Whereで絞り込んだ結果を足しこんでいく(Unionはマージ)
            foreach (Regex r in regexList)
                work = work.Union(sampleData.Where(s => r.IsMatch(s)));
            display.WriteStrings(work);

            display.OutputLine("◇正規表現 OR検索 個数不定 パターン２");
            work = new List<string>(); //空のworkにsampleData.Whereで絞り込んだ結果をセットする
            work = sampleData.Where(s => regexList.Any(r => r.IsMatch(s)));
            display.WriteStrings(work);

            display.OutputLine("◇リバース");
            display.OutputLine(new String(str.Reverse().ToArray())); //ToArray()はChar型の配列を戻り値にもち、String型にセットできる

            display.OutputLine("◇リバース(New Stringを拡張メソッドに…)");
            display.OutputLine(str.Reverse().JoinIntoString());

        }

        private void UseIEnumerableInt(Display display)
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            display.OutputLine("◇Range");
            display.WriteLine(numbers);

            display.OutputLine("◇Sum");
            display.OutputLine(numbers.Sum());

            display.OutputLine("◇Average");
            display.OutputLine(numbers.Average());

            display.OutputLine("◇Min");
            display.OutputLine(numbers.Min());

            display.OutputLine("◇Max");
            display.OutputLine(numbers.Max());

            display.OutputLine("◇Where");
            display.WriteLine(numbers.Where(s => s % 2 == 0));

            display.OutputLine("◇Where.Sum");
            display.OutputLine(numbers.Where(s => s % 2 == 0).Sum());
        }

        private void UseCsvFile(Display display)
        {
            IEnumerable<string> lines = File.ReadAllLines(@"sample.csv");

            foreach (string line in lines)
                { display.OutputLine(line); };
                // なんでlines.ForEachできないのか⇒ForEachを持ってるのはList<T>だから。

        }
    }
}
