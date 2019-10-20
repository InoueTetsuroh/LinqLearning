using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LinqLearning
{
    /// <summary>
    /// 遅延実行するLINQデータソース
    /// </summary>
    class SampleDataSource : IEnumerable<Sample>
    {
        private string _csvFilePath;
        private string _kind;

        private SampleDataSource()
        {
            // 読み取るCSVデータが存在しないと何の意味もないクラスだから
        }

        public static SampleDataSource ReadA(string csvFilePath)
        {
            return new SampleDataSource()
            {
                _csvFilePath = csvFilePath,
                _kind = "A",
            };
        }

        public IEnumerator<Sample> GetEnumerator()
        {
            return GetCsvEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }

        private IEnumerator<Sample> GetCsvEnumerator()
        {
            IEnumerable<string> lines = File.ReadAllLines(_csvFilePath);

            foreach(var line in lines)
            {
                string[] data = line.Split(',');

                //データのKindをチェックする
                string kind = data[0].Trim();
                if (kind != _kind)
                {
                    continue;
                }

                //データの数値を取得する
                int value = 0;
                int.TryParse(data[1].Trim(), out value);

                yield return new Sample() { Kind = kind , Value= value };
                
            }

        }
    }

}
