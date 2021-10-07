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
    public partial class frmCal : Form
    {
        public frmCal()
        {
            InitializeComponent();
        }

        public int Cal(int vMoney, int vYear, double vRate)
        {
            if (rdbYear.Checked)
            {
                return (int)(vMoney * Math.Pow(1 + vRate, vYear));
            }
            else
            {
                return (int)(vMoney * Math.Pow(1 + vRate/12, vYear*12));
            }
        }

    }
}
