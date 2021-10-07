using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsAbstractionDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 使用enum增加程式可讀性
        enum Shape : int
        {
            Circle = 0, Line = 1, Arc = 2
        }

        // 畫圖形
        // vtype = 0 畫圓, vtype = 1 畫線, vtype = 2 畫圓弧
        private void Draw(Shape vtype)
        {
            Graphics g;
            Pen p = new Pen(Color.Red);
            g = this.CreateGraphics();
            g.Clear(Color.White);
            switch (vtype) 
            {
                case Shape.Circle:
                    g.DrawEllipse(p, 90, 30, 90, 90);
                    break;
                case Shape.Line:
                    g.DrawLine(p, 90, 50, 180, 100);
                    break;
                case Shape.Arc:
                    g.DrawArc(p, 90, 30, 90, 90, 0, 250);
                    break;
            }
        }

        // 按畫圓鈕執行btnCircle_Click事件處理函式
        private void btnCircle_Click(object sender, EventArgs e)
        {
            Draw(Shape.Circle);
        }
        // 按畫線鈕執行btnLine_Click事件處理函式
        private void btnLine_Click(object sender, EventArgs e)
        {
            Draw(Shape.Line);
        }

        // 按畫圓弧鈕執行btnArc_Click事件處理函式
        private void btnArc_Click(object sender, EventArgs e)
        {
            Draw(Shape.Arc);
        }
    }
}
