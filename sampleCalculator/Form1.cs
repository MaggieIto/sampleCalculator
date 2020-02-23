using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sampleCalculator
{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        string Input_str = "";
        double Result = 0;
        string Operator = null;

        private void button1_Click_1(object sender, EventArgs e){
            // senderの詳しい情報を取り扱えるようにする (Button)の意味が不明
            Button btn = (Button)sender;
            // 押されたボタンの数字
            string text = btn.Text;
            // [入力された数字]に連結する
            Input_str += text;
            // 画面上に数字を出す
            textBox1.Text = Input_str;
        }
        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}
