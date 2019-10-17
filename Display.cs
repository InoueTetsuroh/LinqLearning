﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LinqLearning
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {

            UseIEnumerableInt();
            
            OutputLine(""); //改行

            UseIEnumerableString();

        }

        private void UseIEnumerableString()
        {
            string str = "LINQ Linq linq";
            
            OutputLine("◇大文字だけCount パターン１");
            OutputLine(str.Where(s => char.IsUpper(s)).Count());
            OutputLine("◇大文字だけCount パターン２");
            OutputLine(str.Count(v => char.IsUpper(v)));

            OutputLine("◇CSVファイルの奇数だけ取得");

            //csvファイルを扱う想定
            str = "1番目,2番目,3番目,4番目,5番目";

            WriteStrings(str.Split(',').Where((s, i) => i % 2 == 0));
            
            OutputLine("◇文字列コレクションから「ぶた」を取得");

            string[] sampleData = { "ぶた", "こぶた", "ぶたまん", "ねぶたまつり", "ねぷたまつり", "きつね", "ねこ" };
            
            //正規表現(System.Text.RegularExpressions;)
            var regex = new Regex("ぶた", RegexOptions.Compiled);

            WriteStrings(sampleData.Where(s => regex.IsMatch(s)));

            OutputLine("◇正規表現 AND検索");

            var regex1 = new Regex("ぶた", RegexOptions.Compiled);
            var regex2 = new Regex("たま", RegexOptions.Compiled);

            WriteStrings(sampleData.Where(s => regex1.IsMatch(s) && regex2.IsMatch(s)));

            OutputLine("◇正規表現 AND検索 個数不定");
            
            List<Regex> regexList = new List<Regex>()
            {
                new Regex("ぶた", RegexOptions.Compiled),
                new Regex("たま", RegexOptions.Compiled),
            };

            IEnumerable<String> work = sampleData; //最初にworkへ全部セットしてからwork.Whereで絞り込んだ結果で絞り込んでいく
            foreach(Regex r in regexList)
                work = work.Where(s => r.IsMatch(s));
            WriteStrings(work);

            OutputLine("◇正規表現 AND検索 個数不定 パターン２");
            
            work = sampleData;
            work = work.Where(s => regexList.All(r => r.IsMatch(s)));　// sampleData.Whereではない！
            WriteStrings(work);

            OutputLine("◇正規表現 OR検索 個数不定");

            work = new List<string>(); //空の状態からsampleData.Whereで絞り込んだ結果を足しこんでいく(Unionはマージ)
            foreach (Regex r in regexList)
                work = work.Union(sampleData.Where(s => r.IsMatch(s)));
            WriteStrings(work);

            OutputLine("◇正規表現 OR検索 個数不定 パターン２");
            work = new List<string>(); //空のworkにsampleData.Whereで絞り込んだ結果をセットする
            work = sampleData.Where(s => regexList.Any(r => r.IsMatch(s)));
            WriteStrings(work);

            OutputLine("◇リバース");
            OutputLine(new String(str.Reverse().ToArray())); //ToArray()はChar型の配列を戻り値にもち、String型にセットできる

            OutputLine("◇リバース(New Stringを拡張メソッドに…)");
            OutputLine(str.Reverse().JoinIntoString());
            
        }

        private void UseIEnumerableInt()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 10);

            OutputLine("◇Range");
            WriteLine(numbers);

            OutputLine("◇Sum");
            OutputLine(numbers.Sum());

            OutputLine("◇Average");
            OutputLine(numbers.Average());

            OutputLine("◇Min");
            OutputLine(numbers.Min());

            OutputLine("◇Max");
            OutputLine(numbers.Max());

            OutputLine("◇Where");
            WriteLine(numbers.Where(s => s % 2 == 0));

            OutputLine("◇Where.Sum");
            OutputLine(numbers.Where(s => s % 2 == 0).Sum());
        }

        private void OutputLine(string str)
        {
            output.Text = output.Text + str + "\r\n";
        }
        private void OutputLine(int num)
        {
            output.Text = output.Text + num.ToString() + "\r\n";
        }
        private void OutputLine(double num)
        {
            output.Text = output.Text + num.ToString() + "\r\n";
        }

        private void WriteLine(IEnumerable<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var n in numbers)
            {
                sb.AppendLine(n.ToString());
            }
            output.Text = output.Text + sb.ToString();
        }

        private void WriteStrings(IEnumerable<string> strings)
        {
            //処理する文字列(n)を[""]で囲んだ形に変換する
            IEnumerable<string> quoted = strings.Select(n => $"\"{n}\"");
            StringBuilder sb = new StringBuilder();
            foreach (var n in quoted)
            {
                sb.AppendLine(n);
            }
            output.Text = output.Text + sb.ToString();
        }
    }
}
