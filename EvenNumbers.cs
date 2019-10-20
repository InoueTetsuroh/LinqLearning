using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqLearning
{
    /// <summary>
    /// 遅延実行しないLINQデータソース
    /// </summary>
    class EvenNumbers
    {
        private List<int> _evenNumbers = new List<int>();
        
        //コンストラクター
        //指定された個数の偶数を生成して保持する
        public EvenNumbers(int count)
        {
            for(int n = 1;n<= count; n++)
            {
                _evenNumbers.Add(n * 2);
            }
        }

        //Linqデータソースとなるプロパティ
        //呼出側で値を変更されないように、ReadOnlyCollectionに変換している
        public IEnumerable<int> Numbers
        {
            get
            {
                return new System.Collections.ObjectModel.ReadOnlyCollection<int>(_evenNumbers);
            }
        }
    }
}
