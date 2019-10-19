using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

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
            DisplayService displayService = new DisplayService();
            displayService.MainService(this);
        }

        public void OutputLine(string str)
        {
            output.Text = output.Text + str + "\r\n";
        }
        public void OutputLine(int num)
        {
            output.Text = output.Text + num.ToString() + "\r\n";
        }
        public void OutputLine(double num)
        {
            output.Text = output.Text + num.ToString() + "\r\n";
        }

        public void WriteLine(IEnumerable<int> numbers)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var n in numbers)
            {
                sb.AppendLine(n.ToString());
            }
            output.Text = output.Text + sb.ToString();
        }

        public void WriteStrings(IEnumerable<string> strings)
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
