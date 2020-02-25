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

        // 0～9と.の計１１個のボタンが対象
        private void button1_Click_1(object sender, EventArgs e){
            // senderの詳しい情報を取り扱えるようにする. type of objectのsenderをtype of Buttonにキャスト
            Button btn = (Button)sender;
            // 押されたボタンの数字
            string text = btn.Text;
            // [入力された数字]に連結する
            Input_str += text;
            // 画面上に数字を出す
            textBox1.Text = Input_str;
        }

        private void button15_Click(object sender, EventArgs e){
            double num1 = Result;
            double num2 = double.Parse(Input_str);
            // 四則演算
            if (Operator == "＋")
                Result = num1 + num2;
            if (Operator == "-")
                Result = num1 - num2;
            if (Operator == "×")
                Result = num1 * num2;
            if (Operator == "÷")
                Result = num1 / num2;

            // 演算子が押されなかった場合、入力されている文字を結果扱いにする
            if (Operator == null)
                Result = num2;

            // 画面に計算結果を表示
            textBox1.Text = Result.ToString();

            // 今入力されている数字をリセットする
            Input_str = "";
            // 演算子をOperator変数に入れる
            Button btnOpe = (Button)sender;
            Operator = btnOpe.Text;

            if (Operator == "=")
                Operator = "";

        }
    }
}
