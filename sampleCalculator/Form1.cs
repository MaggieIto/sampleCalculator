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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string input_str = "";
        double result = 0;
        string operatorBtn = null;

        // 数値入力メソッド. 0～9, 00と.の計12個のボタンが対象.
        private void button1_Click_1(object sender, EventArgs e)
        {
            // senderの詳しい情報を取り扱えるようにする. type of objectのsenderをtype of Buttonにキャスト
            Button btn = (Button)sender;

            // 押されたボタンの数字
            string text = btn.Text;

            DisplayText(text);
        }

        // 数値表示メソッド
        private void DisplayText(string text)
        {
            // 既に入力された文字と新規入力文字と、両方に小数点がある場合、表示をスキップする
            if (!(input_str.Contains(".") && text.Contains(".")))
            {
                // [入力された数字]に連結する
                input_str += text;
            }
            // 画面上に数字を出す
            textBox1.Text = input_str;
        }

        // 計算メソッド. 5個の演算子が対象
        private void button15_Click(object sender, EventArgs e)
        {
            double num1 = result;
            double num2;

            // 入力文字が空欄の場合、計算をスキップする
            if (input_str != "")
            {
                // 入力文字を数字に変換
                num2 = double.Parse(input_str);
                // 四則演算
                if (operatorBtn == "＋")
                    result = num1 + num2;
                if (operatorBtn == "-")
                    result = num1 - num2;
                if (operatorBtn == "×")
                    result = num1 * num2;
                if (operatorBtn == "÷")
                    result = num1 / num2;

                // 演算子が押されなかった場合、入力文字を結果とする
                if (operatorBtn == null)
                    result = num2;
            }
            // 画面に計算結果を表示
            textBox1.Text = result.ToString();

            // 今入力されている数字をリセットする
            input_str = "";
            // 演算子をoperatorBtn変数に入れる
            Button btnOpe = (Button)sender;
            operatorBtn = btnOpe.Text;

            if (operatorBtn == "=")
                operatorBtn = "";
        }
        
        // 桁下げキー（▶）が対象
        private void button19_Click(object sender, EventArgs e)
        {
            var str_carryDown = ""; 
            if (textBox1.Text.Length != 1)
            {
                // 末尾の１文字を削除
                str_carryDown = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                textBox1.Text = str_carryDown;
                input_str = str_carryDown;
            }
            else
            {
                textBox1.Text = "0";
                input_str = str_carryDown;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
