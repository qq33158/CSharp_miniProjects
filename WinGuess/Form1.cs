using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinGuess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int guess, count, min, max;


        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            guess = r.Next(1, 100);
            min = 0;
            max = 100;
            count = 0;
            lblTitle.Text = $"{min} < ? < {max}";
            lblMsg.Text = $"共猜了{count}次";
            btnOk.Enabled = true;
            txtGuess.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int myguess = 0;
            if (int.TryParse(txtGuess.Text, out myguess))
            {
                if (myguess >= 1 && myguess < 100)
                {
                    if (myguess == guess)
                    {
                        count += 1;
                        MessageBox.Show("賓果!!!");
                        btnOk.Enabled = false;
                    }
                    else if (myguess > guess)
                    {
                        count += 1;
                        max = myguess;
                        MessageBox.Show("再小一點!!!");
                        txtGuess.Text = "";
                    }
                    else
                    {
                        count += 1;
                        min = myguess;
                        MessageBox.Show("再大一點!!!");
                        txtGuess.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("請輸入1~99數字");
                }
            }
            else
            {
                MessageBox.Show("請輸入數字");
            }
            lblMsg.Text = $"共猜了{count}次";
            lblTitle.Text = $"{min} < ? < {max}";
        }
        private void btnAgain_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("請問是否離開遊戲嗎?", "猜數字遊戲", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK) ;
            {
                Application.Exit();
            }
        }

    }
}
