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

        public void UseIEnumerableString(Display display)
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

        public void UseIEnumerableInt(Display display)
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

        public void UseCsvFile(Display display)
        {
            IEnumerable<string> lines = File.ReadAllLines(@"sample.csv");

            foreach (string line in lines)
                { display.OutputLine(line); };
            // なんでlines.ForEachできないのか⇒ForEachを持ってるのはList<T>だから。

            display.OutputLine("ReadAllLines End");

            //処理実行

            IEnumerable<Sample> samples = lines.Select(line => Sample.CreateFromCsvFile(display,line));

            display.OutputLine("Select End");

            IEnumerable<Sample> selectedA = samples.Where(sample => Sample.IsKindA(display, sample));

            display.OutputLine("Where End");

            int Sum = selectedA.SumValues(display);

            display.OutputLine("Sum End");

            display.OutputLine($"Aだけの合計は {Sum}");

            // 実行順番が想像と違うはずなので確認すること。
            // Linq拡張メソッド内部のループは分解／再構成されてから実行される。
            // Linqが扱うコレクションには実体がない。（メモリを節約する）
            // Linq拡張メソッドの内部の処理は遅延実行される。

            //残処理実行
            display.OutputLine("残りのデータも合計する");

            IEnumerable<Sample> selectedB = samples.Where(sample => !Sample.IsKindA(display, sample));

            display.OutputLine("Where End");

            int sumB = selectedB.SumValues(display);

            display.OutputLine("Sum End");

            display.OutputLine($"Bだけの合計は {sumB}");

            // ToList,ToArrayの罠(即時実行されてしまう。)　⇒　即時実行されるということはその時点でメモリ展開されるという意味。
            // メモリ展開したほうがいい場合もあるので、ＣＰＵに負荷をかけるか、メモリに負荷をかけるかはトレードオフ

            // ToListした場合の処理順序デモ
            List<Sample> samplesList = lines.Select(line => Sample.CreateFromCsvFile(display, line)).ToList();

            display.OutputLine("Select End");

            IEnumerable<Sample> selectedAList = samplesList.Where(sample => Sample.IsKindA(display, sample));

            display.OutputLine("Where End");

            int SumList = selectedAList.SumValues(display);

            display.OutputLine("Sum End");

            display.OutputLine($"Aだけの合計は {SumList}");

        }
    
        public void MakeLinQExtensionMethod(Display display)
        {
            // 本筋はExtensionクラスを参照
            // LinQ拡張メソッドの性質
            //     拡張メソッドである
            //     入力  はIEnumerable<T> か IQueryable<T>
            //     戻り値はIEnumerable<T> か IQueryable<T> か スカラー(単独の数値またはオブジェクト ex. Sum())
            //     IEumerable<T> か IQueryable<T> 型を返す場合は必要とされたときに実行されること(遅延実行されること)

            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            // LessThenをWhereで表現
            display.WriteLine(numbers.Where(i => i < 4));

            display.OutputLine("");

            // LessThenメソッドを作成
            display.WriteLine(numbers.LessThen(4));
            // 拡張メソッド内でLinqを使うなら上の書き方でよいので現実味がない。
            // 次は拡張メソッド内でLinqを使わない書き方。 LessThenNotLinq

            display.OutputLine("");

            // これは即時実行になるバージョン
            display.WriteLine(numbers.LessThenNotLinq(4));

            display.OutputLine("");

            // これが遅延実行になるバージョン
            display.WriteLine(numbers.LessThenNotList(4));

            display.OutputLine("");

            // LinQ拡張メソッド(ラムダ式定義版)
            display.WriteStrings(numbers.ToQuotedString(n => n < 4));

        }

        public void MakeLinQDataSourceClass(Display display)
        {
            // MakeLinQExtensionMethodで、Linqメソッドの作成についてコーディングした。
            // このメソッドでは、Linqの先頭(ListやIEnumerable,String[])の作成についてコーディングする。(⇒LinqDataSourceと呼ぶこととする)

            // LinqDataSourceはIEnumerable<T>型のクラスか、IEnumeraable<T>型を返すメソッド／プロパティを持ったクラス。
            EvenNumbers even = new EvenNumbers(10);
            display.WriteLine(even.Numbers.Select(n => n));

            display.OutputLine("");

            var samples = SampleDataSource.ReadA(@".\sample.csv");
            foreach (var s in samples)
                display.OutputLine($"Kind={ s.Kind} , Value={s.Value}");

            display.OutputLine("");

            var over100 = samples.Where(s =>
                                        {
                                            display.OutputLine(($"{ s.Kind} , {s.Value}"));　// 検証用
                                            return s.Value > 100;
                                        }
            );
            
            foreach (var s in over100)
                display.OutputLine($"Kind={ s.Kind} , Value={s.Value}");

        }
    }
}
