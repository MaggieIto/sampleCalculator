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
        string input_str = "";
        double result = 0;
        string operatorBtnOrKey = null;

        public Form1()
        {
            InitializeComponent();
            KeyPress += new KeyPressEventHandler(keyPress);
        }
        // 数値入力メソッド. 0～9, 00と.の計12個のボタンが対象.
        private void button1_Click_1(object sender, EventArgs e)
        {
            // senderの詳しい情報を取り扱えるようにする. type of objectのsenderをtype of Buttonにキャスト
            Button btn = (Button)sender;

            // 押されたボタンの数字
            string text = btn.Text;
            DisplayText(text);
        }

        // keyboardによる入力メソッド
        private void keyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;
            string text = keyChar.ToString();

            // 数字の場合
            if (text.Any("0123456789.".Contains))
            {
                DisplayText(text);
            }
            // 演算子の場合
            else if (text.Any("+-*/=".Contains))
            {
                DisplayResult(operatorBtnOrKey);
                operatorBtnOrKey = text;
            }
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

        // 演算子入力メソッド. 5個の演算子が対象
        private void button15_Click(object sender, EventArgs e)
        {
            // 演算子をoperatorBtnOrKey変数に入れる
            // 一つ前の演算子による計算を実行後、今回押された演算子をoperatorBtnOrKeyに代入
            DisplayResult(operatorBtnOrKey);
            Button btnOpe = (Button)sender;
            operatorBtnOrKey = btnOpe.Text;
        }

        // 計算結果表示メソッド
        private void DisplayResult(string operatorBtnOrKey)
        {
            double num1 = result;
            double num2;

            // 入力文字が空欄の場合、計算をスキップする
            if (input_str != "")
            {
                // 入力文字を数字に変換
                num2 = double.Parse(input_str);
                // 四則演算
                if (operatorBtnOrKey == "＋" || operatorBtnOrKey == "+")
                    result = num1 + num2;
                if (operatorBtnOrKey == "-")
                    result = num1 - num2;
                if (operatorBtnOrKey == "×" || operatorBtnOrKey == "*")
                    result = num1 * num2;
                if (operatorBtnOrKey == "÷" || operatorBtnOrKey == "/")
                    result = num1 / num2;

                // 演算子が押されなかった場合、入力文字を結果とする
                if (operatorBtnOrKey == null)
                    result = num2;
            }
            // 画面に計算結果を表示
            textBox1.Text = result.ToString();

            // 今入力されている数字をリセットする
            input_str = "";

            // ＝が入力された場合、それをリセットする
            if (operatorBtnOrKey == "=")
                operatorBtnOrKey = "";
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
