using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsPolymorphism.Class1;

namespace WindowsFormsPolymorphism
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Cal myCal;
        CalAdd myCalAdd = new CalAdd();
        CalSub myCalSub = new CalSub();
        CalMul myCalMul = new CalMul();
        CalDiv myCalDiv = new CalDiv();
        private void Form1_Load(object sender, EventArgs e)
        {
            myCal = myCalAdd;
            txtAns.ReadOnly = true;
        }

        private void rdbAdd_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalAdd;
        }

        private void rdbSub_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalSub;
        }
        private void rdbMul_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalMul;
        }
        private void rdbDiv_CheckedChanged(object sender, EventArgs e)
        {
            myCal = myCalDiv;
        }
        private void btnCal_Click(object sender, EventArgs e)
        {
            try
            {
                myCal.X = int.Parse(txtX.Text);
                myCal.Y = int.Parse(txtY.Text);
                txtAns.Text = myCal.Answer().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
