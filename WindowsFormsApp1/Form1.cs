﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class From1 : Form
    {
        public From1()
        {
            InitializeComponent();
        }
        // 表單載入時執行
        private void Form1_Load(object sender, EventArgs e)
        {
            lblShow.Text = "";
        }
        // 按確認鈕執行此事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            lblShow.Text = "Hello, " + txtName.Text;
            lblShow.BackColor = Color.Yellow;
        }
        // 按結束鈕執行此事件
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
