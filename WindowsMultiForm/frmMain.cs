using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsMultiForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblShow.Text = "";
            // 指定目前表單為MDI表單的容器
            // this.IsMdiContainer = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            int myMoney = 0, myYear = 0;
            double myRate = 0;
            try
            {
                myMoney = int.Parse(txtMoney.Text);
                myYear = int.Parse(txtYear.Text);
                myRate = double.Parse(txtRate.Text) / 100;
            }
            catch(Exception ex)
            {
                MessageBox.Show("請輸入正確數值資料");
                return;
            }
            frmCal f = new frmCal();
            f.ShowDialog();
            lblShow.Text = $"{myYear} 年後領回本利和:{f.Cal(myMoney, myYear, myRate)}";
        }

        private void btnOpenCal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\WINDOWS\\system32\\calc.exe");
        }
    }
}
